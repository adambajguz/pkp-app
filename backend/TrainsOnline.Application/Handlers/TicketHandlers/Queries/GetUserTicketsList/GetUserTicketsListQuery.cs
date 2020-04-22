namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetUserTicketsList
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class GetUserTicketsListQuery : IRequest<GetTicketsListResponse>
    {
        public IdRequest Data { get; }

        public GetUserTicketsListQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetUserTicketsListQuery, GetTicketsListResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IDataRightsService drs)
            {
                _uow = uow;
                _drs = drs;

            }

            public async Task<GetTicketsListResponse> Handle(GetUserTicketsListQuery request, CancellationToken cancellationToken)
            {
                _drs.ValidateUserId(request.Data, x => x.Id);

                Guid userId = request.Data.Id;

                return new GetTicketsListResponse
                {
                    Ticket = await _uow.TicketsRepository.ProjectToAsync<GetTicketsListResponse.TicketLookupModel>(x => x.UserId == userId, cancellationToken: cancellationToken)
                };
            }
        }
    }
}

