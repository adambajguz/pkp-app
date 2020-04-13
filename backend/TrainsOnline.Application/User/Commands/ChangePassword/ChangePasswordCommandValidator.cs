namespace TrainsOnline.Application.User.Commands.ChangePassword
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Helpers;
    using TrainsOnline.Common;

    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommandValidator.Model>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.Data.UserId).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectUser);

            RuleFor(x => x.Data.OldPassword).Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return PasswordHelper.ValidatePassword(val, userResult.Password);
            }).WithMessage(ValidationMessages.Password.OldIsIncorrect);

            RuleFor(x => x.Data.OldPassword).NotEmpty()
                                            .WithMessage(ValidationMessages.Password.IsEmpty);
            RuleFor(x => x.Data.OldPassword).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                            .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH));

            RuleFor(x => x.Data.NewPassword).NotEmpty()
                                            .WithMessage(ValidationMessages.Password.IsEmpty);
            RuleFor(x => x.Data.NewPassword).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                            .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH));

            //RuleFor(x => x.Data.NewPassword).Must((request, val, token) =>
            //{
            //    if (val.Equals(request.Data.OldPassword))
            //        return false;

            //    return true;
            //}).WithMessage(ValidationMessages.Password.NewIsEqualToOld).WithErrorCode(ValidationErrorCodes.Password.NewIsEqualToOld);
        }

        public class Model
        {
            public ChangePasswordRequest Data { get; set; }
            public User User { get; set; }

            public Model(ChangePasswordRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
