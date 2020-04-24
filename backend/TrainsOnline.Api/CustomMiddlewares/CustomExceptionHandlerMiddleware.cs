namespace TrainsOnline.Api.CustomMiddlewares
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Application.Exceptions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Serilog;
    using TrainsOnline.Api.Models;

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code = exception switch
            {
                FluentValidation.ValidationException _ => HttpStatusCode.BadRequest,
                BadUserException _ => HttpStatusCode.Forbidden,
                ForbiddenException _ => HttpStatusCode.Forbidden,
                NotFoundException _ => HttpStatusCode.NotFound,
                _ => HandleUnknownException(exception)
            };

            object response = new
            {
                statusCode = code,
                message = exception.Message,
                errors = exception is FluentValidation.ValidationException vex ? (object)new ValidationResultModel(vex) : null,
                //stackTrace = exception.StackTrace,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static HttpStatusCode HandleUnknownException(Exception exception)
        {
            Log.Error(exception, "Unhandled exception in CustomExceptionHandlerMiddleware");

            return HttpStatusCode.InternalServerError;
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
