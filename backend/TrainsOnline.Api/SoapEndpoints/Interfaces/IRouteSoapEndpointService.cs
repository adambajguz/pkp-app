namespace TrainsOnline.Api.SoapEndpoints.Interfaces
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.CreateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.UpdateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.CreateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList;
    using TrainsOnline.Domain.Jwt;

    [ServiceContract]
    public interface IRouteSoapEndpointService : ISoapEndpointService
    {
        [SoapAuthorize(Roles = Roles.Admin)]
        [OperationContract]
        Task<IdResponse> CreateRoute(CreateRouteRequest route);

        [OperationContract]
        Task<GetRouteDetailResponse> GetRouteDetails(IdRequest id);

        [SoapAuthorize(Roles = Roles.Admin)]
        [OperationContract]
        Task<Unit> UpdateRoute(UpdateRouteRequest route);

        [SoapAuthorize(Roles = Roles.Admin)]
        [OperationContract]
        Task<Unit> DeleteRoute(IdRequest id);

        [OperationContract]
        Task<GetRoutesListResponse> GetRoutesList();
    }
}