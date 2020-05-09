﻿namespace TrainsOnline.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CSharpVitamins;
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
        public const string Create = nameof(CreateTicket);
        public const string GetDetails = nameof(GetTicketDetails);
        public const string GetDocument = nameof(GetTicketDocument);
        public const string ValidateDocument = nameof(GetValidateDocument);
        public const string Update = nameof(UpdateStation);
        public const string Delete = nameof(DeleteTicket);
        public const string GetCurrentUser = nameof(GetCurrentUserTicketsList);
        public const string GetUser = nameof(GetUserTicketsList);
        public const string GetAll = nameof(GetTicketsList);

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
        [HttpGet("/api/ticket/get/{id:guid}")]
        [SwaggerOperation(
            Summary = "Get ticket details [User]",
            Description = "Gets ticket details")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetTicketDetailsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetTicketDetails([FromRoute]Guid id)
        {
            return Ok(await Mediator.Send(new GetTicketDetailsQuery(new IdRequest(id))));
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("/api/ticket/get-document/{id:guid}")]
        [SwaggerOperation(
            Summary = "Get ticket document [User]",
            Description = "Gets ticket document")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetTicketDocumentResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetTicketDocument([FromRoute]Guid id)
        {
            return Ok(await Mediator.Send(new GetTicketDocumentQuery(new IdRequest(id))));
        }

        [HttpGet("/api/ticket/validate-document")] // ?tid={}&uid={}&rid={}
        [SwaggerOperation(
            Summary = "Validate ticket document",
            Description = "Gets ticket document validation result")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetValidateDocument([FromQuery]string tid, [FromQuery]string uid, [FromQuery]string rid)
        {
            ShortGuid tidSG = new ShortGuid(tid);
            ShortGuid uidSG = new ShortGuid(uid);
            ShortGuid ridSG = new ShortGuid(rid);

            return base.Ok(await Mediator.Send(new ValidateDocumentQuery(tidSG, uidSG, ridSG)));
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
        [HttpDelete("/api/ticket/delete/{id:guid}")]
        [SwaggerOperation(
            Summary = "Delete ticket [" + Roles.Admin + "]",
            Description = "Deletes ticket")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket deleted")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ExceptionResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> DeleteTicket([FromRoute]Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTicketCommand(new IdRequest(id))));
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
        [HttpGet("/api/ticket/get-all-user/{id:guid}")]
        [SwaggerOperation(
            Summary = "Get all user tickets [" + Roles.User + "]",
            Description = "Gets a list of all user tickets")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetUserTicketsListResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, null, typeof(ExceptionResponse))]
        public async Task<IActionResult> GetUserTicketsList([FromRoute]Guid id)
        {
            return Ok(await Mediator.Send(new GetUserTicketsListQuery(new IdRequest(id))));
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
