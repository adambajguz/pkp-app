namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetFilteredRoutesList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetFilteredRoutesListQuery : IRequest<GetRoutesListResponse>
    {
        public GetFilteredRoutesListQuery()
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
                    Routes = await _uow.RoutesRepository.ProjectToWithRelatedAsync<GetRoutesListResponse.RouteLookupModel, Station, Station>(relatedSelector0: x => x.From,
                                                                                                                                             relatedSelector1: x => x.To,
                                                                                                                                             cancellationToken: cancellationToken)
                };
            }
        }
    }
}

