namespace TrainsOnline.Application.Route.Commands.CreateRoute
{
    using TrainsOnline.Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class CreateRouteCommandValidator : AbstractValidator<CreateRouteRequest>
    {
        public CreateRouteCommandValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Email).NotEmpty()
                                 .WithMessage(ValidationMessages.Email.IsEmpty);
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage(ValidationMessages.Email.HasWrongFormat);
            RuleFor(x => x.Email).MustAsync(async (request, val, token) =>
            {
                bool checkInUse = await uow.UsersRepository.IsEmailInUseAsync(val);

                return !checkInUse;

            }).WithMessage(ValidationMessages.Email.IsInUse);
        }
    }
}
