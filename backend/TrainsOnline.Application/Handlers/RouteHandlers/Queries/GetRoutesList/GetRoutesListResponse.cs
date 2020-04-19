﻿namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList
{
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;

    public class GetRoutesListResponse : IDataTransferObject
    {
        public IList<GetRouteDetailResponse> Routes { get; set; } = default!;
    }
}
