namespace TrainsOnline.Application.Main.User.Commands.UpdateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class UpdateUserCommand : IRequest
    {
        public UpdateUserRequest Data { get; }

        public UpdateUserCommand(UpdateUserRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<UpdateUserCommand, Unit>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IMapper _mapper;
            private readonly IDataRightsService _drs;

            public Handler(IMainDbUnitOfWork uow, IMapper mapper, IDataRightsService drs)
            {
                _uow = uow;
                _mapper = mapper;
                _drs = drs;
            }

            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                UpdateUserRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
                UpdateUserCommandValidator.Model validationModel = new UpdateUserCommandValidator.Model(data, user);

                await new UpdateUserCommandValidator(_uow).ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _mapper.Map(data, user);
                _uow.UsersRepository.Update(user);

                await _uow.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
