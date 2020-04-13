namespace TrainsOnline.Application.User.Commands.ChangePassword
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Helpers;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class ChangePasswordCommand : IRequest
    {
        public ChangePasswordRequest Data { get; }

        public ChangePasswordCommand(ChangePasswordRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<ChangePasswordCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IDataRightsService drs)
            {
                _uow = uow;
                _drs = drs;
            }

            public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                ChangePasswordRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.UserId);

                User user = await _uow.UsersRepository.GetByIdAsync(data.UserId);
                ChangePasswordCommandValidator.Model validationModel = new ChangePasswordCommandValidator.Model(data, user);

                await new ChangePasswordCommandValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                user.Password = PasswordHelper.CreateHash(data.NewPassword);

                _uow.UsersRepository.Update(user);

                await _uow.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
