namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;

    public interface IRouteData
    {
        //Task<RouteDetailsValueObject> GetRoute(Guid id);
        //Task<IList<RouteDetailsValueObject>> GetRoutes();

        Task<GetRouteDetailsResponse> GetRoute(Guid id);
        Task<GetStationsListResponse> GetFilteredStations(GetFilteredRoutesListRequest data);
        Task<GetRoutesListResponse> GetRoutes();
    }
}
