namespace TrainsOnline.Desktop.Infrastructure.DTO.Station
{
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class CreateStationRequest : IDataTransferObject
    {
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
