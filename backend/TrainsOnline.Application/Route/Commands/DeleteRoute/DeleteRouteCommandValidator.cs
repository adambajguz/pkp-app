namespace TrainsOnline.Application.Route.Commands.DeleteRoute
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.DTO;

    public class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommandValidator.Model>
    {
        public DeleteRouteCommandValidator()
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
