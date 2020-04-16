namespace TrainsOnline.Application.Authentication.Commands.ResetPassword
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;

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
