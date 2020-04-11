namespace TrainsOnline.Application.Main.User.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Application.Common.Helpers;
    using Application.Common.Interfaces.UoW;
    using Application.CommonDTO;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class CreateUserCommand : IRequest<IdResponse>
    {
        public CreateUserRequest Data { get; }

        public CreateUserCommand(CreateUserRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<CreateUserCommand, IdResponse>
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

            public async Task<IdResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                CreateUserRequest data = request.Data;

                await new CreateUserCommandValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                User entity = _mapper.Map<User>(data);
                entity.Password = PasswordHelper.CreateHash(data.Password);

                _uow.UsersRepository.Add(entity);

                await _uow.SaveChangesAsync(cancellationToken);

                return new IdResponse(entity.Id);
            }
        }
    }
}
