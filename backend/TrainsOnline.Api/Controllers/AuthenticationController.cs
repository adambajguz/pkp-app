﻿namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Application.Authentication.Commands.ResetPassword;
    using Application.Authentication.Queries.GetResetPasswordToken;
    using TrainsOnline.Application.Main.Authentication.Queries.GetValidToken;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("User authentication and password reset")]
    public class AuthenticationController : BaseController
    {
        [HttpPost("/api/login")]
        [SwaggerOperation(
            Summary = "Login a user",
            Description = "Authenticates a user")]
        [SwaggerResponse(200, "User authenticated", typeof(JwtTokenModel))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> Login([FromBody]LoginRequest model)
        {
            return Ok(await Mediator.Send(new GetValidTokenQuery(model)));
        }

        [HttpPost("/api/resetPassword")]
        [SwaggerOperation(
            Summary = "Send password reset link",
            Description = "Sends e-mail with password reset link")]
        [SwaggerResponse(200, "Password reset e-mail sent")]
        [SwaggerResponse(400)]
        public async Task<IActionResult> ResetPassword([FromBody]SendResetPasswordRequest request)
        {
            return Ok(await Mediator.Send(new GetResetPasswordTokenQuery(request)));
        }

        [HttpPost("/api/resetPassword/change")]
        [SwaggerOperation(
            Summary = "Reset user password",
            Description = "Resets user's password using password reset token")]
        [SwaggerResponse(200, "User password was changed")]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordRequest request)
        {
            return Ok(await Mediator.Send(new ResetPasswordCommand(request)));
        }
    }
}
