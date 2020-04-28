namespace TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation
{
    using System;
    using TrainsOnline.Application.DTO;

    public class UpdateStationRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
