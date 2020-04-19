namespace TrainsOnline.Application.Route.Commands.UpdateRoute
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommandValidator.Model>
    {
        public UpdateRouteCommandValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                User userResult = request.User;
                if (userResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);

            RuleFor(x => x.Data.Email).NotEmpty()
                                      .WithMessage(ValidationMessages.Email.IsEmpty);
            RuleFor(x => x.Data.Email).EmailAddress()
                                      .WithMessage(ValidationMessages.Email.HasWrongFormat);

            When(x => x.User != null, () =>
            {
                RuleFor(x => x.Data.Email).MustAsync(async (request, val, token) =>
                {
                    User userResult = request.User;

                    if (userResult.Email.Equals(val))
                        return true;

                    bool checkInUse = await uow.UsersRepository.IsEmailInUseAsync(val!);

                    return !checkInUse;

                }).WithMessage(ValidationMessages.Email.IsInUse);
            });
        }

        public class Model
        {
            public UpdateRouteRequest Data { get; set; }
            public User User { get; set; }

            public Model(UpdateRouteRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
