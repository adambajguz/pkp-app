namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.CreateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.DeleteRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Commands.UpdateRoute;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update and get user")]
    public class RouteController : BaseController
    {
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/route/create")]
        [SwaggerOperation(
            Summary = "Create (register) new route",
            Description = "Creates a new route")]
        [SwaggerResponse(200, "Route created", typeof(IdResponse))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> Registration([FromBody]CreateRouteRequest route)
        {
            return Ok(await Mediator.Send(new CreateRouteCommand(route)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/route/get")]
        [SwaggerOperation(
            Summary = "Get route details",
            Description = "Gets route details")]
        [SwaggerResponse(200, null, typeof(GetRouteDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUserDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetRouteDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/route/update")]
        [SwaggerOperation(
            Summary = "Updated route details",
            Description = "Updates route details")]
        [SwaggerResponse(200, "Route details updated")]
        [SwaggerResponse(401)]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateRouteRequest route)
        {
            return Ok(await Mediator.Send(new UpdateRouteCommand(route)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/route/delete")]
        [SwaggerOperation(
            Summary = "Delete route",
            Description = "Deletes route")]
        [SwaggerResponse(200, "Route deleted")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> DeleteUser([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteRouteCommand(id)));
        }

        [HttpGet("/api/route/get-all")]
        [SwaggerOperation(
            Summary = "Get all routes",
            Description = "Gets a list of all routes")]
        [SwaggerResponse(200, null, typeof(GetRoutesListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(await Mediator.Send(new GetRoutesListQuery()));
        }
    }
}
