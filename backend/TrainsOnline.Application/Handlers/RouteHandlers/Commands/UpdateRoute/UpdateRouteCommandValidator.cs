namespace TrainsOnline.Application.RouteHandlers.Commands.UpdateRoute
{
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommandValidator.Model>
    {
        public UpdateRouteCommandValidator(IPKPAppDbUnitOfWork uow)
        {

        }

        public class Model
        {
            public UpdateRouteRequest Data { get; set; }
            public Route Route { get; set; }

            public Model(UpdateRouteRequest data, Route route)
            {
                Data = data;
                Route = route;
            }
        }
    }
}
