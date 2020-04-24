namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Application.Interfaces.Pdf;
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

                Ticket entity = await _uow.TicketsRepository.GetByIdAsync(data.Id);
                await _drs.ValidateUserId(entity, x => x.UserId);

                byte[] document = _documents.NewDocument()
                                            .AddSection()
                                            .BuildPdf();

                GetTicketDocumentResponse response = _mapper.Map<GetTicketDocumentResponse>(entity);
                response.Document = document;

                return response;
            }
        }
    }
}
