namespace TrainsOnline.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Route.Commands.CreateRoute;
    using TrainsOnline.Application.Route.Commands.DeleteRoute;
    using TrainsOnline.Application.Route.Commands.UpdateRoute;
    using TrainsOnline.Application.Route.Queries.GetRouteDetails;
    using TrainsOnline.Application.Route.Queries.GetRoutesList;
    using TrainsOnline.Application.User.Commands.ChangePassword;
    using TrainsOnline.Application.User.Commands.CreateUser;
    using TrainsOnline.Application.User.Commands.DeleteUser;
    using TrainsOnline.Application.User.Commands.UpdateUser;
    using TrainsOnline.Application.User.Queries.GetUserDetails;
    using TrainsOnline.Application.User.Queries.GetUsersList;
    using TrainsOnline.Domain.Jwt;

    [SwaggerTag("Create, update and get user")]
    public class UserController : BaseController
    {
        [HttpPost("/api/user/register")]
        [SwaggerOperation(
            Summary = "Create (register) new user",
            Description = "Creates a new user")]
        [SwaggerResponse(200, "User created", typeof(IdResponse))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> Registration([FromBody]CreateUserRequest user)
        {
            return Ok(await Mediator.Send(new CreateUserCommand(user)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("/api/user/self")]
        [SwaggerOperation(
            Summary = "Get authenticated user details",
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
            Summary = "Get user details",
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
            Summary = "Updated user details",
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
            Summary = "Delete user",
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
            Summary = "Change user password",
            Description = "Changes password of an user")]
        [SwaggerResponse(200, "Password changed")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordRequest user)
        {
            return Ok(await Mediator.Send(new ChangePasswordCommand(user)));
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("/api/user/get-all")]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Gets a list of all users")]
        [SwaggerResponse(200, null, typeof(GetUsersListResponse))]
        [SwaggerResponse(401)]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }
    }
}
