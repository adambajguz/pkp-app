namespace TrainsOnline.Desktop.Application.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;

    public interface IRemoteDataProviderService
    {
        bool UseSoapApi { get; set; }

        Task<GetStationDetailsResponse> GetStation(Guid id);
        Task<GetStationsListResponse> GetStations();

        Task<GetRouteDetailsResponse> GetRoute(Guid id);
        Task<GetRoutesListResponse> GetRoutes();
    }
}
