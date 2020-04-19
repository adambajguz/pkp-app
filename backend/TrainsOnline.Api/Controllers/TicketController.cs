namespace TrainsOnline.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.DeleteTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetUserTicketsList;
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

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get")]
        [SwaggerOperation(
            Summary = "Get ticket details [User]",
            Description = "Gets ticket details")]
        [SwaggerResponse(200, null, typeof(GetTicketDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetTicketDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetTicketDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get-document")]
        [SwaggerOperation(
            Summary = "Get ticket document [User]",
            Description = "Gets ticket document")]
        [SwaggerResponse(200, null, typeof(GetTicketDocumentResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetTicketDocument([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetTicketDocumentQuery(id)));
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

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get-all-current-user")]
        [SwaggerOperation(
            Summary = "Get all current user tickets",
            Description = "Gets a list of all current user tickets [User]")]
        [SwaggerResponse(200, null, typeof(GetTicketsListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetCurrentUserTicketsList()
        {
            IdRequest data = new IdRequest((Guid)DataRights.GetUserIdFromContext()!);

            return Ok(await Mediator.Send(new GetUserTicketsListQuery(data)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get-all-user")]
        [SwaggerOperation(
            Summary = "Get all user tickets",
            Description = "Gets a list of all user tickets [User]")]
        [SwaggerResponse(200, null, typeof(GetTicketsListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUserTicketsList([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetUserTicketsListQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("/api/ticket/get-all")]
        [SwaggerOperation(
            Summary = "Get all tickets",
            Description = "Gets a list of all tickets [Admin]")]
        [SwaggerResponse(200, null, typeof(GetTicketsListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetTicketsList()
        {
            return Ok(await Mediator.Send(new GetTicketsListQuery()));
        }
    }
}
