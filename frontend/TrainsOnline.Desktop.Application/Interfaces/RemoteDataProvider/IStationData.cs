namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.ValueObjects.StationComponents;

    public interface IStationData
    {
        //Task<StationDetailsValueObject> GetStation(Guid id);
        //Task<IList<StationDetailsValueObject>> GetStations();

        Task<GetStationDetailsResponse> GetStation(Guid id);
        Task<GetStationsListResponse> GetStations();
    }
}
