namespace TrainsOnline.Application.Authentication.Commands.ResetPassword
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Common;

    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommandValidator.Model>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.User.Id).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectUser);

            RuleFor(x => x.Data.Password).NotEmpty()
                                         .WithMessage(ValidationMessages.Password.IsEmpty);
            RuleFor(x => x.Data.Password).MinimumLength(GlobalAppConfig.MIN_PASSWORD_LENGTH)
                                         .WithMessage(string.Format(ValidationMessages.Password.IsTooShort, GlobalAppConfig.MIN_PASSWORD_LENGTH));
        }

        public class Model
        {
            public ResetPasswordRequest Data { get; set; }
            public User User { get; set; }

            public Model(ResetPasswordRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
