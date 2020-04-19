namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList
{
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;

    public class GetStationsListResponse : IDataTransferObject
    {
        public IList<GetStationDetailResponse> Stations { get; set; } = default!;
    }
}
