namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.CreateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.DeleteStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update and get station")]
    public class StationController : BaseController
    {
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/create")]
        [SwaggerOperation(
            Summary = "Create new station [Admin]",
            Description = "Creates a new station")]
        [SwaggerResponse(200, "Station created", typeof(IdResponse))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> CreateStation([FromBody]CreateStationRequest station)
        {
            return Ok(await Mediator.Send(new CreateStationCommand(station)));
        }

        [HttpPost("/api/route/get")]
        [SwaggerOperation(
            Summary = "Get station details",
            Description = "Gets station details")]
        [SwaggerResponse(200, null, typeof(GetStationDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetStationDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetStationDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/update")]
        [SwaggerOperation(
            Summary = "Updated station details [Admin]",
            Description = "Updates station details")]
        [SwaggerResponse(200, "Station details updated")]
        [SwaggerResponse(401)]
        public async Task<IActionResult> UpdateStation([FromBody]UpdateStationRequest station)
        {
            return Ok(await Mediator.Send(new UpdateStationCommand(station)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/delete")]
        [SwaggerOperation(
            Summary = "Delete station [Admin]",
            Description = "Deletes station")]
        [SwaggerResponse(200, "Station deleted")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> DeleteStation([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteStationCommand(id)));
        }

        [HttpGet("/api/station/get-all")]
        [SwaggerOperation(
            Summary = "Get all routes",
            Description = "Gets a list of all stations")]
        [SwaggerResponse(200, null, typeof(GetStationsListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetStationsList()
        {
            return Ok(await Mediator.Send(new GetStationsListQuery()));
        }
    }
}
