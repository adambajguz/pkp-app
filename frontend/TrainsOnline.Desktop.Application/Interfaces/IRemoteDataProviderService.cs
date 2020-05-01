namespace TrainsOnline.Desktop.Application.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.Route;
    using TrainsOnline.Desktop.Domain.Station;

    public interface IRemoteDataProviderService
    {
        bool UseSoapApi { get; set; }

        Task<GetStationDetailsResponse> GetStation(Guid id);
        Task<GetStationsListResponse> GetStations();

        Task<GetRouteDetailsResponse> GetRoute(Guid id);
        Task<GetRoutesListResponse> GetRoutes();
    }
}
