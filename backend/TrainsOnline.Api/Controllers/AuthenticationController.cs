﻿namespace TrainsOnline.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Commands.ResetPassword;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetResetPasswordToken;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetValidToken;

    [SwaggerTag("User authentication and password reset")]
    public class AuthenticationController : BaseController
    {
        [HttpPost("/api/user/login")]
        [SwaggerOperation(
            Summary = "Login a user",
            Description = "Authenticates a user")]
        [SwaggerResponse(StatusCodes.Status200OK, "User authenticated", typeof(JwtTokenModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody]LoginRequest model)
        {
            return Ok(await Mediator.Send(new GetValidTokenQuery(model)));
        }

        [HttpPost("/api/user/reset-password")]
        [SwaggerOperation(
            Summary = "Send password reset link (Reset password step 1)",
            Description = "Sends e-mail with password reset link")]
        [SwaggerResponse(StatusCodes.Status200OK, "Password reset e-mail sent")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordStep1([FromBody]SendResetPasswordRequest request)
        {
            return Ok(await Mediator.Send(new GetResetPasswordTokenQuery(request)));
        }

        [HttpPost("/api/user/reset-password/change")]
        [SwaggerOperation(
            Summary = "Reset user password (Reset password step 2)",
            Description = "Resets user's password using password reset token")]
        [SwaggerResponse(StatusCodes.Status200OK, "User password was changed")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ResetPasswordStep2([FromBody]ResetPasswordRequest request)
        {
            return Ok(await Mediator.Send(new ResetPasswordCommand(request)));
        }
    }
}
