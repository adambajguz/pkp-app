namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.DeleteTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update, and get ticket")]
    public class TicketController : BaseController
    {
        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/create")]
        [SwaggerOperation(
            Summary = "Create new ticket [User]",
            Description = "Creates a new ticket")]
        [SwaggerResponse(200, "Ticket created", typeof(IdResponse))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketRequest ticket)
        {
            return Ok(await Mediator.Send(new CreateTicketCommand(ticket)));
        }

        [HttpPost("/api/ticket/get")]
        [SwaggerOperation(
            Summary = "Get ticket details",
            Description = "Gets ticket details")]
        [SwaggerResponse(200, null, typeof(GetTicketDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetTicketDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetTicketDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/ticket/update")]
        [SwaggerOperation(
            Summary = "Updated ticket details [Admin]",
            Description = "Updates ticket details")]
        [SwaggerResponse(200, "Ticket details updated")]
        [SwaggerResponse(401)]
        public async Task<IActionResult> UpdateStation([FromBody]UpdateTicketRequest ticket)
        {
            return Ok(await Mediator.Send(new UpdateTicketCommand(ticket)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/api/ticket/delete")]
        [SwaggerOperation(
            Summary = "Delete ticket [Admin]",
            Description = "Deletes ticket")]
        [SwaggerResponse(200, "Ticket deleted")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> DeleteTicket([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteTicketCommand(id)));
        }

        [HttpGet("/api/ticket/get-all")]
        [SwaggerOperation(
            Summary = "Get all tickets",
            Description = "Gets a list of all tickets")]
        [SwaggerResponse(200, null, typeof(GetTicketsListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetTicketsList()
        {
            return Ok(await Mediator.Send(new GetTicketsListQuery()));
        }
    }
}
