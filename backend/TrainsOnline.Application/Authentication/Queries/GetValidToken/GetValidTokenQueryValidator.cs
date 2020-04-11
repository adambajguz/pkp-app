namespace TrainsOnline.Application.Main.Authentication.Queries.GetValidToken
{
    using Application.Common.Helpers;
    using Application.Constants;
    using TrainsOnline.Common;
    using Domain.Entities;
    using FluentValidation;

    public class GetValidTokenQueryValidator : AbstractValidator<GetValidTokenQueryValidator.Model>
    {
        public GetValidTokenQueryValidator()
        {
            RuleFor(x => x.Data.Email).NotEmpty()
                                      .WithMessage(ValidationMessages.Email.IsEmpty)
                                      .WithErrorCode(ValidationErrorCodes.Email.IsEmpty);
            RuleFor(x => x.Data.Email).EmailAddress()
                                      .WithMessage(ValidationMessages.Email.HasWrongFormat)
                                      .WithErrorCode(ValidationErrorCodes.Email.HasWrongFormat);

            RuleFor(x => x.Data.Password).NotEmpty()
                                         .WithMessage(ValidationMessages.Password.IsEmpty)
                                         .WithErrorCode(ValidationErrorCodes.Password.IsEmpty);
            RuleFor(x => x.Data.Password).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                         .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH))
                                         .WithErrorCode(ValidationErrorCodes.Password.IsTooShort);

            RuleFor(x => x.User).Must((request, val, token) =>
            {
                if (val == null)
                    return false;
                else if (PasswordHelper.ValidatePassword(request.Data.Password, val.Password))
                    return true;

                return false;

            }).WithMessage(ValidationMessages.Auth.EmailOrPasswordIsIncorrect).WithErrorCode(ValidationErrorCodes.Auth.EmailOrPasswordIsIncorrect);
        }

        public class Model
        {
            public LoginRequest Data { get; set; }
            public User User { get; set; }

            public Model(LoginRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
