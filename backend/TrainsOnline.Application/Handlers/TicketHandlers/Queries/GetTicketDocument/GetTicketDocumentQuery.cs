namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Application.Interfaces.Documents;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetTicketDocumentQuery : IRequest<GetTicketDocumentResponse>
    {
        public IdRequest Data { get; }

        public GetTicketDocumentQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetTicketDocumentQuery, GetTicketDocumentResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;
            private readonly IDataRightsService _drs;
            private readonly IDocumentsService _documents;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper, IDataRightsService drs, IDocumentsService documents)
            {
                _uow = uow;
                _mapper = mapper;
                _drs = drs;
                _documents = documents;
            }

            public async Task<GetTicketDocumentResponse> Handle(GetTicketDocumentQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                Ticket entity = await _uow.TicketsRepository.GetByIdWithRelatedAsync(data.Id, x => x.Route, x => x.Route.From, x => x.Route.To);

                EntityRequestByIdValidator<Ticket>.Model validationModel = new EntityRequestByIdValidator<Ticket>.Model(data, entity);
                await new EntityRequestByIdValidator<Ticket>().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);
                await _drs.ValidateUserId(entity, x => x.UserId);

                using (MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(PdfHeaderImage.Image)))
                {
                    DateTime arrival = entity.Route.DepartureTime.Add(entity.Route.Duration);
                    Color color = Color.FromArgb(57, 89, 158);

                    byte[] document = _documents.NewDocument()
                                                .AddSection()

                                                .AddComplexParagraph()
                                                .AddImage(memoryStream, 160, 30)
                                                .AddNewLine(2)
                                                .FinishParagraph()

                                                .AddComplexParagraph()
                                                .AddRunLine("────────────────────────────────┤ TICKET ├─────────────────────────────────", bold: true, fontColor: color)
                                                .AddRun("         TID  ", bold: true, fontColor: color).AddRunLine($"PKP Ticket {{{entity.Id}}}")
                                                .AddRun("   TIMESTAMP  ", bold: true, fontColor: color).AddRunLine(entity.LastSavedOn.ToString())
                                                .AddRun("       ROUTE  ", bold: true, fontColor: color).AddRunLine($"{entity.Route.From.Name} → {entity.Route.To.Name}")
                                                .AddRun("   DEPARTURE  ", bold: true, fontColor: color).AddRunLine(entity.Route.DepartureTime.ToString())
                                                .AddNewLine(3)
                                                .AddRunLine("───────────────────────────────┤ PASSENGER ├───────────────────────────────", bold: true, fontColor: color)
                                                .AddRun("         UID  ", bold: true, fontColor: color).AddRunLine($"{{{entity.UserId}}}")
                                                .AddRun("        NAME  ", bold: true, fontColor: color).AddRunLine($"{entity.User.Name} {entity.User.Surname}")
                                                .AddRun("      E-MAIL  ", bold: true, fontColor: color).AddRunLine(entity.User.Email)
                                                .AddRun("     ADDRESS  ", bold: true, fontColor: color).AddRunLine(entity.User.Address)
                                                .AddRun("       PHONE  ", bold: true, fontColor: color).AddRunLine(entity.User.PhoneNumber)
                                                .AddNewLine(3)
                                                .AddRunLine("─────────────────────────────┤ ROUTE DETAILS ├─────────────────────────────", bold: true, fontColor: color)
                                                .AddRun("        RUID  ", bold: true, fontColor: color).AddRunLine($"{{{entity.RouteId}}}")
                                                .AddRun("  CREATED ON  ", bold: true, fontColor: color).AddRunLine(entity.CreatedOn.ToString())
                                                .FinishParagraph()

                                                .AddSimpleTable(new object[,]
                                                {
                                                    { "Departure",                           "Arrival",           "Travel time",          "Distance",                    "Ticket price"                 },
                                                    { entity.Route.From.Name,                entity.Route.To.Name, entity.Route.Duration, $"{entity.Route.Distance} km", $"${entity.Route.TicketPrice}" },
                                                    { entity.Route.DepartureTime.ToString(), arrival,             "",                     "",                           ""                             },
                                                })

                                                .FinishSection()

                                                .BuildPdf();

                    GetTicketDocumentResponse response = _mapper.Map<GetTicketDocumentResponse>(entity);
                    response.Document = document;

                    return response;
                }
            }
        }
    }
}
