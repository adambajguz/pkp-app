namespace TrainsOnline.Application.RouteHandlers.Commands.CreateRoute
{
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class CreateRouteCommandValidator : AbstractValidator<CreateRouteRequest>
    {
        public CreateRouteCommandValidator(IPKPAppDbUnitOfWork uow)
        {

        }
    }
}
