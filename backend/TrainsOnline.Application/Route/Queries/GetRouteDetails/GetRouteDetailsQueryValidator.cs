namespace TrainsOnline.Application.Route.Queries.GetRouteDetails
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class GetRouteDetailsQueryValidator : AbstractValidator<IdRequest>
    {
        public GetRouteDetailsQueryValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Id).NotEmpty().MustAsync(async (request, val, token) =>
            {
                User userResult = await uow.UsersRepository.GetByIdAsync(request.Id);
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }
    }
}
