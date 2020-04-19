namespace TrainsOnline.Application.UserHandlers.Queries.GetUserDetails
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetUserDetailsQueryValidator : AbstractValidator<IdRequest>
    {
        public GetUserDetailsQueryValidator(IPKPAppDbUnitOfWork uow)
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
