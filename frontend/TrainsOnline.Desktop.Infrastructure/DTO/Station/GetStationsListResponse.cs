namespace TrainsOnline.Desktop.Infrastructure.DTO.Station
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Desktop.Infrastructure.DTO;

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
