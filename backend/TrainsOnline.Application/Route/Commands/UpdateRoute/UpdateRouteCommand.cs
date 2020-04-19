namespace TrainsOnline.Application.Route.Commands.UpdateRoute
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateRouteCommand : IRequest
    {
        public UpdateRouteRequest Data { get; }

        public UpdateRouteCommand(UpdateRouteRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<UpdateRouteCommand, Unit>
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

            public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
            {
                UpdateRouteRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
                UpdateRouteCommandValidator.Model validationModel = new UpdateRouteCommandValidator.Model(data, user);

                await new UpdateRouteCommandValidator(_uow).ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _mapper.Map(data, user);
                _uow.UsersRepository.Update(user);

                await _uow.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
