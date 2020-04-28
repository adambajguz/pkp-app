namespace TrainsOnline.Application.Handlers.StationHandlers.Commands.CreateStation
{
    using TrainsOnline.Application.DTO;

    public class CreateStationRequest : IDataTransferObject
    {
        public string? Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
