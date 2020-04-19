namespace TrainsOnline.Application.Route.Commands.CreateRoute
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class CreateRouteCommand : IRequest<IdResponse>
    {
        public CreateRouteRequest Data { get; }

        public CreateRouteCommand(CreateRouteRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<CreateRouteCommand, IdResponse>
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

            public async Task<IdResponse> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
            {
                CreateRouteRequest data = request.Data;

                await new CreateRouteCommandValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                User entity = _mapper.Map<User>(data);
                await _userManager.SetPassword(entity, data.Password, cancellationToken);

                _uow.UsersRepository.Add(entity);

                await _uow.SaveChangesAsync(cancellationToken);

                return new IdResponse(entity.Id);
            }
        }
    }
}
