namespace TrainsOnline.Application.Main.User.Commands.CreateUser
{
    using Application.Common.Interfaces.UoW;
    using Application.Constants;
    using TrainsOnline.Common;
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserCommandValidator(IMainDbUnitOfWork uow)
        {
            RuleFor(x => x.Username).NotEmpty()
                                    .WithMessage(ValidationMessages.Username.IsEmpty)
                                    .WithErrorCode(ValidationErrorCodes.Username.IsEmpty);
            RuleFor(x => x.Username).MinimumLength(GlobalAppConfig.MIN_USERNAME_LENGTH)
                                    .WithMessage(string.Format(ValidationMessages.Username.IsTooShort, GlobalAppConfig.MIN_USERNAME_LENGTH))
                                    .WithErrorCode(ValidationErrorCodes.Username.IsTooShort);
            RuleFor(x => x.Username).MustAsync(async (request, val, token) =>
            {
                bool checkInUse = await uow.UsersRepository.IsUserNameInUseAsync(val);

                return !checkInUse;
            }).WithMessage(ValidationMessages.Username.IsInUse).WithErrorCode(ValidationErrorCodes.Username.IsInUse);

            RuleFor(x => x.Email).NotEmpty()
                                 .WithMessage(ValidationMessages.Email.IsEmpty)
                                 .WithErrorCode(ValidationErrorCodes.Email.IsEmpty);
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage(ValidationMessages.Email.HasWrongFormat)
                                 .WithErrorCode(ValidationErrorCodes.Email.HasWrongFormat);
            RuleFor(x => x.Email).MustAsync(async (request, val, token) =>
            {
                bool checkInUse = await uow.UsersRepository.IsEmailInUseAsync(val);

                return !checkInUse;

            }).WithMessage(ValidationMessages.Email.IsInUse).WithErrorCode(ValidationErrorCodes.Email.IsInUse);

            RuleFor(x => x.Password).NotEmpty()
                                    .WithMessage(ValidationMessages.Password.IsEmpty)
                                    .WithErrorCode(ValidationErrorCodes.Password.IsEmpty);
            RuleFor(x => x.Password).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                    .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH))
                                    .WithErrorCode(ValidationErrorCodes.Password.IsTooShort);
        }
    }
}
