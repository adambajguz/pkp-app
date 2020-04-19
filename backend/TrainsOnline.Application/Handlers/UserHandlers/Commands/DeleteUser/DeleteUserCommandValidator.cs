namespace TrainsOnline.Application.Handlers.UserHandlers.Commands.DeleteUser
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Domain.Entities;

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommandValidator.Model>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }

        public class Model
        {
            public IdRequest Data { get; set; }
            public User User { get; set; }

            public Model(IdRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
