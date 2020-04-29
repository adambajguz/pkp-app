namespace TrainsOnline.Desktop.Application.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.Station;

    public interface IRemoteDataProviderService
    {
        bool UseSoapApi { get; set; }
        Task<GetStationsListResponse> GetStations();
        Task<GetStationDetailsResponse> GetStation(Guid id);
    }
}
