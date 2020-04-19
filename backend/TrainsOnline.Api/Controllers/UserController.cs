namespace TrainsOnline.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.UserHandlers.Commands.ChangePassword;
    using TrainsOnline.Application.Handlers.UserHandlers.Commands.CreateUser;
    using TrainsOnline.Application.Handlers.UserHandlers.Commands.DeleteUser;
    using TrainsOnline.Application.Handlers.UserHandlers.Commands.UpdateUser;
    using TrainsOnline.Application.Handlers.UserHandlers.Queries.GetUserDetails;
    using TrainsOnline.Application.Handlers.UserHandlers.Queries.GetUsersList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update, and get user")]
    public class UserController : BaseController
    {
        [HttpPost("/api/user/create")]
        [SwaggerOperation(
            Summary = "Create (register) a new user",
            Description = "Creates a new user")]
        [SwaggerResponse(200, "User created", typeof(IdResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest user)
        {
            return Ok(await Mediator.Send(new CreateUserCommand(user)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("/api/user/get-current")]
        [SwaggerOperation(
            Summary = "Get authenticated user details [User]",
            Description = "Gets authenticated user details based on token")]
        [SwaggerResponse(200, null, typeof(GetUserDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            IdRequest data = new IdRequest((Guid)DataRights.GetUserIdFromContext()!);

            return Ok(await Mediator.Send(new GetUserDetailsQuery(data)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/user/get")]
        [SwaggerOperation(
            Summary = "Get user details [User]",
            Description = "Gets user details")]
        [SwaggerResponse(200, null, typeof(GetUserDetailResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUserDetails([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery(id)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/user/update")]
        [SwaggerOperation(
            Summary = "Updated user details [User]",
            Description = "Updates user details")]
        [SwaggerResponse(200, "User details updated")]
        [SwaggerResponse(401)]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserRequest user)
        {
            return Ok(await Mediator.Send(new UpdateUserCommand(user)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/user/delete")]
        [SwaggerOperation(
            Summary = "Delete user [User]",
            Description = "Deletes user")]
        [SwaggerResponse(200, "User deleted")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> DeleteUser([FromBody]IdRequest id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand(id)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("/api/user/change-password")]
        [SwaggerOperation(
            Summary = "Change user password [User]",
            Description = "Changes password of an user")]
        [SwaggerResponse(200, "Password changed")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordRequest user)
        {
            return Ok(await Mediator.Send(new ChangePasswordCommand(user)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("/api/user/get-all")]
        [SwaggerOperation(
            Summary = "Get all users [Admin]",
            Description = "Gets a list of all users")]
        [SwaggerResponse(200, null, typeof(GetUsersListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }
    }
}
