namespace TrainsOnline.Application.User.Commands.CreateUser
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Common;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserCommandValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Username).NotEmpty()
                                    .WithMessage(ValidationMessages.Username.IsEmpty);
            RuleFor(x => x.Username).MinimumLength(GlobalAppConfig.MIN_USERNAME_LENGTH)
                                    .WithMessage(string.Format(ValidationMessages.Username.IsTooShort, GlobalAppConfig.MIN_USERNAME_LENGTH));
            RuleFor(x => x.Username).MustAsync(async (request, val, token) =>
            {
                bool checkInUse = await uow.UsersRepository.IsUserNameInUseAsync(val);

                return !checkInUse;
            }).WithMessage(ValidationMessages.Username.IsInUse);

            RuleFor(x => x.Email).NotEmpty()
                                 .WithMessage(ValidationMessages.Email.IsEmpty);
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage(ValidationMessages.Email.HasWrongFormat);
            RuleFor(x => x.Email).MustAsync(async (request, val, token) =>
            {
                bool checkInUse = await uow.UsersRepository.IsEmailInUseAsync(val);

                return !checkInUse;

            }).WithMessage(ValidationMessages.Email.IsInUse);
        }
    }
}
