namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces;
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

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper, IDataRightsService drs)
            {
                _uow = uow;
                _mapper = mapper;
                _drs = drs;
            }

            public async Task<GetTicketDocumentResponse> Handle(GetTicketDocumentQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetTicketDocumentQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Ticket entity = await _uow.TicketsRepository.GetByIdAsync(data.Id);
                _drs.ValidateUserId(entity, x => x.UserId);

                return _mapper.Map<GetTicketDocumentResponse>(entity);
            }
        }
    }
}
