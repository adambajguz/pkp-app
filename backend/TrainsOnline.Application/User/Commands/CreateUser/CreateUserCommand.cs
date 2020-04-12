namespace TrainsOnline.Application.User.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Helpers;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Common.DTO;

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
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper, IDataRightsService drs)
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
