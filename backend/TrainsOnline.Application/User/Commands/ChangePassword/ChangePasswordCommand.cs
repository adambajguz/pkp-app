namespace TrainsOnline.Application.Main.User.Commands.ChangePassword
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Helpers;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class ChangePasswordCommand : IRequest
    {
        public ChangePasswordRequest Data { get; }

        public ChangePasswordCommand(ChangePasswordRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<ChangePasswordCommand, Unit>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IMainDbUnitOfWork uow, IDataRightsService drs)
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
