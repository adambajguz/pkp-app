namespace TrainsOnline.Application.Handlers.UserHandlers.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class CreateUserCommand : IRequest<IdResponse>
    {
        public CreateUserRequest Data { get; }

        public CreateUserCommand(CreateUserRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<CreateUserCommand, IdResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;
            private readonly IUserManagerService _userManager;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper, IUserManagerService userManager)
            {
                _uow = uow;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<IdResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                CreateUserRequest data = request.Data;

                await new CreateUserCommandValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                User entity = _mapper.Map<User>(data);
                await _userManager.SetPassword(entity, data.Password, cancellationToken);

                _uow.UsersRepository.Add(entity);

                await _uow.SaveChangesAsync(cancellationToken);

                return new IdResponse(entity.Id);
            }
        }
    }
}
