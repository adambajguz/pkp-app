namespace TrainsOnline.Application.Main.User.Commands.UpdateUser
{
    using Application.Common.Interfaces.UoW;
    using Application.Constants;
    using TrainsOnline.Common;
    using Domain.Entities;
    using FluentValidation;

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandValidator.Model>
    {
        public UpdateUserCommandValidator(IMainDbUnitOfWork uow)
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectUser).WithErrorCode(ValidationErrorCodes.Id.IsIncorrectUser);

            RuleFor(x => x.Data.Username).NotEmpty()
                                         .WithMessage(ValidationMessages.Username.IsEmpty)
                                         .WithErrorCode(ValidationErrorCodes.Username.IsEmpty);
            RuleFor(x => x.Data.Username).MinimumLength(GlobalAppConfig.MIN_USERNAME_LENGTH)
                                         .WithMessage(string.Format(ValidationMessages.Username.IsTooShort, GlobalAppConfig.MIN_USERNAME_LENGTH))
                                         .WithErrorCode(ValidationErrorCodes.Username.IsTooShort);

            RuleFor(x => x.Data.Email).NotEmpty()
                                      .WithMessage(ValidationMessages.Email.IsEmpty)
                                      .WithErrorCode(ValidationErrorCodes.Email.IsEmpty);
            RuleFor(x => x.Data.Email).EmailAddress()
                                      .WithMessage(ValidationMessages.Email.HasWrongFormat)
                                      .WithErrorCode(ValidationErrorCodes.Email.HasWrongFormat);

            When(x => x.User != null, () =>
            {
                RuleFor(x => x.Data.Username).MustAsync(async (request, val, token) =>
                {
                    User userResult = request.User;

                    if (userResult.Username.Equals(val))
                        return true;

                    bool checkInUse = await uow.UsersRepository.IsUserNameInUseAsync(val);

                    return !checkInUse;
                }).WithMessage(ValidationMessages.Username.IsInUse).WithErrorCode(ValidationErrorCodes.Username.IsInUse);

                RuleFor(x => x.Data.Email).MustAsync(async (request, val, token) =>
                {
                    User userResult = request.User;

                    if (userResult.Email.Equals(val))
                        return true;

                    bool checkInUse = await uow.UsersRepository.IsEmailInUseAsync(val);

                    return !checkInUse;

                }).WithMessage(ValidationMessages.Email.IsInUse).WithErrorCode(ValidationErrorCodes.Email.IsInUse);
            });
        }

        public class Model
        {
            public UpdateUserRequest Data { get; set; }
            public User User { get; set; }

            public Model(UpdateUserRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
