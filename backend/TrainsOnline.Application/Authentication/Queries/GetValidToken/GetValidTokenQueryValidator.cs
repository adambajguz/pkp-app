namespace TrainsOnline.Application.Authentication.Queries.GetValidToken
{
    using Application.Common.Helpers;
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Common;

    public class GetValidTokenQueryValidator : AbstractValidator<GetValidTokenQueryValidator.Model>
    {
        public GetValidTokenQueryValidator()
        {
            RuleFor(x => x.Data.Email).NotEmpty()
                                      .WithMessage(ValidationMessages.Email.IsEmpty);
            RuleFor(x => x.Data.Email).EmailAddress()
                                      .WithMessage(ValidationMessages.Email.HasWrongFormat);

            RuleFor(x => x.Data.Password).NotEmpty()
                                         .WithMessage(ValidationMessages.Password.IsEmpty);
            RuleFor(x => x.Data.Password).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                         .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH));

            RuleFor(x => x.User).Must((request, val, token) =>
            {
                if (val == null)
                    return false;
                else if (PasswordHelper.ValidatePassword(request.Data.Password, val.Password))
                    return true;

                return false;

            }).WithMessage(ValidationMessages.Auth.EmailOrPasswordIsIncorrect);
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
