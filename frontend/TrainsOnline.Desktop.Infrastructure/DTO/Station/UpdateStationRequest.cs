namespace TrainsOnline.Desktop.Infrastructure.DTO.Station
{
    using System;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class UpdateStationRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
