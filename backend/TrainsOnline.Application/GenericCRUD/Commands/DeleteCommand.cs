namespace TrainsOnline.Application.GenericCRUD.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Common.DTO;
    using TrainsOnline.Application.User.Commands.DeleteUser;

    public class DeleteCommand : IRequest
    {
        public IdRequest Data { get; }

        public DeleteCommand(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<DeleteUserCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IDataRightsService drs)
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
