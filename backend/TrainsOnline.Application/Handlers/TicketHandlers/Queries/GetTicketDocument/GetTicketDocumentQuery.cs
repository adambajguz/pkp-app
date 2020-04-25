namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
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
                    byte[] document = _documents.NewDocument()
                                                .AddSection()

                                                .AddComplexParagraph()
                                                .AddImage(@"pdf-header.png", 160, 30)
                                                .AddImage(memoryStream, 160, 30)
                                                .AddNewLine()
                                                .AddNewLine()
                                                .AddRunLine($"PKP Ticket {{{entity.Id}}}")
                                                .AddRunLine(entity.CreatedOn.ToString())
                                                .AddRunLine(entity.User.Email)
                                                .AddRunLine(entity.User.Address)
                                                .AddRunLine(entity.User.Name)
                                                .AddRunLine(entity.User.Surname)
                                                .FinishParagraph()

                                                .AddComplexParagraph()
                                                .AddRunLine(entity.Route.From.Name)
                                                .AddRunLine(entity.Route.To.Name)
                                                .AddRunLine(entity.Route.DepartureTime.ToString())
                                                .AddRunLine(entity.Route.Duration.ToString())
                                                .AddRunLine(entity.Route.Distance.ToString())
                                                .FinishParagraph()
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
