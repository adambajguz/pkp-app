namespace TrainsOnline.Application.Main.User.Queries.GetUserDetails
{
    using Application.Common.Interfaces.UoW;
    using Application.CommonDTO;
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;

    public class GetUserDetailsQueryValidator : AbstractValidator<IdRequest>
    {
        public GetUserDetailsQueryValidator(IMainDbUnitOfWork uow)
        {
            RuleFor(x => x.Id).NotEmpty().MustAsync(async (request, val, token) =>
            {
                User userResult = await uow.UsersRepository.GetByIdAsync(request.Id);
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectUser).WithErrorCode(ValidationErrorCodes.Id.IsIncorrectUser);
        }
    }
}
