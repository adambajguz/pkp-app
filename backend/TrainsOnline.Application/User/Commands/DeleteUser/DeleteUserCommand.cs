namespace TrainsOnline.Application.Main.User.Commands.DeleteUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces.UoW;
    using Application.CommonDTO;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class DeleteUserCommand : IRequest
    {
        public IdRequest Data { get; }

        public DeleteUserCommand(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<DeleteUserCommand, Unit>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IMainDbUnitOfWork uow, IDataRightsService drs)
            {
                _uow = uow;
                _drs = drs;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
                DeleteUserCommandValidator.Model validationModel = new DeleteUserCommandValidator.Model(data, user);

                await new DeleteUserCommandValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _uow.UsersRepository.Remove(user);
                await _uow.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
