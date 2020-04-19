namespace TrainsOnline.Application.RouteHandlers.Queries.GetRouteDetails
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetRouteDetailsQueryValidator : AbstractValidator<IdRequest>
    {
        public GetRouteDetailsQueryValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Id).NotEmpty().MustAsync(async (request, val, token) =>
            {
                Route routeResult = await uow.UsersRepository.GetByIdAsync(request.Id);
                if (routeResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }
    }
}
