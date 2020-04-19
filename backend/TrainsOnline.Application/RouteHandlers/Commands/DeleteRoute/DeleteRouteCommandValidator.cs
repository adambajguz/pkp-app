namespace TrainsOnline.Application.RouteHandlers.Commands.DeleteRoute
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.DTO;

    public class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommandValidator.Model>
    {
        public DeleteRouteCommandValidator()
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                Route routeResult = request.Route;
                if (routeResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }

        public class Model
        {
            public IdRequest Data { get; set; }
            public Route Route { get; set; }

            public Model(IdRequest data, Route route)
            {
                Data = data;
                Route = route;
            }
        }
    }
}
