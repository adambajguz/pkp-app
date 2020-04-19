namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class GetRoutesListQuery : IRequest<GetRoutesListResponse>
    {
        public GetRoutesListQuery()
        {

        }

        public class Handler : IRequestHandler<GetRoutesListQuery, GetRoutesListResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<GetRoutesListResponse> Handle(GetRoutesListQuery request, CancellationToken cancellationToken)
            {
                return new GetRoutesListResponse
                {
                    Routes = await _uow.RoutesRepository.ProjectTo<GetRouteDetailResponse>(cancellationToken: cancellationToken)
                };
            }
        }
    }
}

