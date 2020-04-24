﻿namespace TrainsOnline.Application.Handlers.UserHandlers.Commands.UpdateUser
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandValidator.Model>
    {
        public UpdateUserCommandValidator(IPKPAppDbUnitOfWork uow)
        {
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
            public UpdateUserRequest Data { get; set; }
            public User User { get; set; }

            public Model(UpdateUserRequest data, User user)
            {
                Data = data;
                User = user;
            }
        }
    }
}
