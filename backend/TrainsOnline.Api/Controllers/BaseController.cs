namespace TrainsOnline.Api.Controllers
{
    using Application.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator? _mediator;
        private ICurrentUserService? _currentUser;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected ICurrentUserService CurrentUser => _currentUser ?? (_currentUser = HttpContext.RequestServices.GetService<ICurrentUserService>());
    }
}
