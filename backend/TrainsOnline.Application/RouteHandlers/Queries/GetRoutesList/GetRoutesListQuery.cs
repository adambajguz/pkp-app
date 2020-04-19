namespace TrainsOnline.Application.RouteHandlers.Queries.GetRoutesList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Application.RouteHandlers.Queries.GetRouteDetails;

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
                    Routes = await _uow.UsersRepository.ProjectTo<GetRouteDetailResponse>(cancellationToken: cancellationToken)
                };
            }
        }
    }
}

