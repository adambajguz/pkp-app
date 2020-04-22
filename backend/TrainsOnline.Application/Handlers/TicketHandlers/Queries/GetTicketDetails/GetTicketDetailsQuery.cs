namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails
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

    public class GetTicketDetailsQuery : IRequest<GetTicketDetailsResponse>
    {
        public IdRequest Data { get; }

        public GetTicketDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetTicketDetailsQuery, GetTicketDetailsResponse>
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

            public async Task<GetTicketDetailsResponse> Handle(GetTicketDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetTicketDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Ticket entity = await _uow.TicketsRepository.GetByIdWithRelatedAsync(data.Id, x => x.Route, x => x.Route.From, x => x.Route.To);
                _drs.ValidateUserId(entity, x => x.UserId);

                return _mapper.Map<GetTicketDetailsResponse>(entity);
            }
        }
    }
}
