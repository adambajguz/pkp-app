namespace TrainsOnline.Application.User.Commands.ChangePassword
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces;

    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommandValidator.Model>
    {
        public ChangePasswordCommandValidator(IUserManagerService _userManager)
        {
            RuleFor(x => x.Data.UserId).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectUser);

            RuleFor(x => x.Data.OldPassword).MustAsync(async (request, val, token) => await _userManager.ValidatePassword(request.User, val))
                                            .WithMessage(ValidationMessages.Password.OldIsIncorrect);
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
