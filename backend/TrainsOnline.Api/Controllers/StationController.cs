namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.CreateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.DeleteStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update, and get station")]
    public class StationController : BaseController
    {
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/create")]
        [SwaggerOperation(
            Summary = "Create new station [" + Roles.Admin + "]",
            Description = "Creates a new station")]
        [SwaggerResponse(StatusCodes.Status200OK, "Station created", typeof(IdResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateStation([FromBody]CreateStationRequest station)
        {
            return Ok(await Mediator.Send(new CreateStationCommand(station)));
        }

        [HttpPost("/api/station/get")]
        [SwaggerOperation(
            Summary = "Get station details",
            Description = "Gets station details")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetStationDetailsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStationDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetStationDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/update")]
        [SwaggerOperation(
            Summary = "Updated station details [" + Roles.Admin + "]",
            Description = "Updates station details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Station details updated")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateStation([FromBody]UpdateStationRequest station)
        {
            return Ok(await Mediator.Send(new UpdateStationCommand(station)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/station/delete")]
        [SwaggerOperation(
            Summary = "Delete station [" + Roles.Admin + "]",
            Description = "Deletes station")]
        [SwaggerResponse(StatusCodes.Status200OK, "Station deleted")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteStation([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteStationCommand(id)));
        }

        [HttpGet("/api/station/get-all")]
        [SwaggerOperation(
            Summary = "Get all stations",
            Description = "Gets a list of all stations")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetStationsListResponse))]
        public async Task<IActionResult> GetStationsList()
        {
            return Ok(await Mediator.Send(new GetStationsListQuery()));
        }
    }
}
