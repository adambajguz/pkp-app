namespace TrainsOnline.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Api.CustomMiddlewares.Exceptions;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.DeleteTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetUserTicketsList;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.ValidateDocument;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update, and get ticket")]
    public class TicketController : BaseController
    {
        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/create")]
        [SwaggerOperation(
            Summary = "Create new ticket [User]",
            Description = "Creates a new ticket")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket created", typeof(IdResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketRequest ticket)
        {
            return Ok(await Mediator.Send(new CreateTicketCommand(ticket)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get")]
        [SwaggerOperation(
            Summary = "Get ticket details [User]",
            Description = "Gets ticket details")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetTicketDetailsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetTicketDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetTicketDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get-document")]
        [SwaggerOperation(
            Summary = "Get ticket document [User]",
            Description = "Gets ticket document")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetTicketDocumentResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetTicketDocument([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetTicketDocumentQuery(id)));
        }   
        
        [HttpPost("/api/ticket/validate-document")]
        [SwaggerOperation(
            Summary = "Validate ticket document",
            Description = "Gets ticket document validation result")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetValidateDocument([FromRoute]Guid tid, [FromRoute]Guid uid, [FromRoute]Guid rid)
        {
            return Ok(await Mediator.Send(new ValidateDocumentQuery(tid, uid, rid)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("/api/ticket/update")]
        [SwaggerOperation(
            Summary = "Updated ticket details [" + Roles.Admin + "]",
            Description = "Updates ticket details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket details updated")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> UpdateStation([FromBody]UpdateTicketRequest ticket)
        {
            return Ok(await Mediator.Send(new UpdateTicketCommand(ticket)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("/api/ticket/delete")]
        [SwaggerOperation(
            Summary = "Delete ticket [" + Roles.Admin + "]",
            Description = "Deletes ticket")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket deleted")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> DeleteTicket([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteTicketCommand(id)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("/api/ticket/get-all-current-user")]
        [SwaggerOperation(
            Summary = "Get all current user tickets [" + Roles.User + "]",
            Description = "Gets a list of all current user tickets")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetUserTicketsListResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetCurrentUserTicketsList()
        {
            IdRequest data = new IdRequest((Guid)CurrentUser.UserId!);

            return Ok(await Mediator.Send(new GetUserTicketsListQuery(data)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/ticket/get-all-user")]
        [SwaggerOperation(
            Summary = "Get all user tickets [" + Roles.User + "]",
            Description = "Gets a list of all user tickets")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetUserTicketsListResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetUserTicketsList([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetUserTicketsListQuery(id)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("/api/ticket/get-all")]
        [SwaggerOperation(
            Summary = "Get all tickets [" + Roles.Admin + "]",
            Description = "Gets a list of all tickets")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetTicketsListResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetTicketsList()
        {
            return Ok(await Mediator.Send(new GetTicketsListQuery()));
        }
    }
}
