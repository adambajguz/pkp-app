namespace TrainsOnline.Api.SoapEndpoints
{
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Api.SoapEndpoints.Interfaces;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.CreateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.DeleteRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.UpdateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.CreateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.DeleteStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList;
    using TrainsOnline.Application.Interfaces;

    [SoapRoute("[baseUrl]/station", "Station", "Create, update and get station")]
    public class StationSoapEndpointService : IStationSoapEndpointService
    {
        protected IMediator Mediator { get; }
        protected IDataRightsService DataRights { get; }

        public StationSoapEndpointService(IMediator mediator, IDataRightsService dataRights)
        {
            Mediator = mediator;
            DataRights = dataRights;
        }

        public async Task<IdResponse> CreateStation(CreateRouteRequest route)
        {
            return await Mediator.Send(new CreateRouteCommand(route));
        }

        public async Task<GetRouteDetailResponse> GetStationDetails(IdRequest id)
        {
            return await Mediator.Send(new GetRouteDetailsQuery(id));
        }

        public async Task<Unit> UpdateStation(UpdateRouteRequest route)
        {
            return await Mediator.Send(new UpdateRouteCommand(route));
        }

        public async Task<Unit> DeleteStation(IdRequest id)
        {
            return await Mediator.Send(new DeleteRouteCommand(id));
        }

        public async Task<GetRoutesListResponse> GetStationsList()
        {
            return await Mediator.Send(new GetRoutesListQuery());
        }
    }
}
