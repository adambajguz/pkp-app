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
        private IDataRightsService? _dataRights;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected IDataRightsService DataRights => _dataRights ?? (_dataRights = HttpContext.RequestServices.GetService<IDataRightsService>());
    }
}
