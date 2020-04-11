namespace TrainsOnline.Api.Filters
{
    using System;
    using System.Net;
    using TrainsOnline.Api.Models;
    using Application.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.Clear();
            context.Result = new JsonResult(null);

            if (context.Exception is ForbiddenException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                return;
            }
            else if (context.Exception is FluentValidation.ValidationException ex)
            {
                //REMOVE validaitonresultmodel add own class in application
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new ValidationResultModel(ex));

                return;
            }

            HttpStatusCode code = HttpStatusCode.InternalServerError;
            //if (context.Exception is NotFoundException)
            //    code = HttpStatusCode.NotFound;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });

        }
    }
}
