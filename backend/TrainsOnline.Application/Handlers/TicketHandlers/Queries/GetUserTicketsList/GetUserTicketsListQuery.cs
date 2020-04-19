namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetUserTicketsList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
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

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<GetTicketsListResponse> Handle(GetUserTicketsListQuery request, CancellationToken cancellationToken)
            {
                return new GetTicketsListResponse
                {
                    Ticket = await _uow.TicketsRepository.ProjectTo<GetTicketDetailResponse>(cancellationToken: cancellationToken)
                };
            }
        }
    }
}

