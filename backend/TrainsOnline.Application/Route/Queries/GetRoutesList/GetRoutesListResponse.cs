namespace TrainsOnline.Application.Route.Queries.GetRoutesList
{
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Route.Queries.GetRouteDetails;

    public class GetRoutesListResponse : IDataTransferObject
    {
        public IList<GetRouteDetailResponse> Routes { get; set; } = default!;
    }
}
