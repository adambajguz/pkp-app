namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;

    public class GetStationsListResponse : IDataTransferObject
    {
        public List<StationLookupModel> Stations { get; set; }

        public class StationLookupModel : IDataTransferObject
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }
}
