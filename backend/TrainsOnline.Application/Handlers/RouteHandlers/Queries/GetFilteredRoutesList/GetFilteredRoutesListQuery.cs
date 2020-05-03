﻿namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetFilteredRoutesList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetFilteredRoutesListQuery : IRequest<GetRoutesListResponse>
    {
        public GetFilteredRoutesListRequest Data { get; }

        public GetFilteredRoutesListQuery(GetFilteredRoutesListRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetFilteredRoutesListQuery, GetRoutesListResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IStringSimilarityComparerService _strComparer;

            public Handler(IPKPAppDbUnitOfWork uow,
                           IStringSimilarityComparerService strComparer)
            {
                _uow = uow;
                _strComparer = strComparer;
            }

            public async Task<GetRoutesListResponse> Handle(GetFilteredRoutesListQuery request, CancellationToken cancellationToken)
            {
                GetFilteredRoutesListRequest data = request.Data;

                GetRoutesListResponse routes = new GetRoutesListResponse
                {
                    Routes = await _uow.RoutesRepository.ProjectToWithRelatedAsync<GetRoutesListResponse.RouteLookupModel, Station, Station>(relatedSelector0: x => x.From,
                                                                                                                                             relatedSelector1: x => x.To,
                                                                                                                                             //filter: (x) => data.MaximumTicketPrice == null || x.TicketPrice <= data.MaximumTicketPrice,
                                                                                                                                             cancellationToken: cancellationToken)
                };

                if (data.MaximumTicketPrice is double max)
                    routes.Routes.RemoveAll(x => x.TicketPrice > max);

                if (data.FromPattern is string from)
                    routes.Routes.RemoveAll(x => _strComparer.AreNotSimilar(x.From.Name, from));

                if (data.ToPattern is string to)
                    routes.Routes.RemoveAll(x => _strComparer.AreNotSimilar(x.To.Name, to));

                return routes;
            }
        }
    }
}

