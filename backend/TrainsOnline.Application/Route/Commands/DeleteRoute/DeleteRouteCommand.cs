namespace TrainsOnline.Application.Route.Commands.DeleteRoute
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class DeleteRouteCommand : IRequest
    {
        public IdRequest Data { get; }

        public DeleteRouteCommand(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<DeleteRouteCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IDataRightsService drs)
            {
                _uow = uow;
                _drs = drs;
            }

            public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
                DeleteRouteCommandValidator.Model validationModel = new DeleteRouteCommandValidator.Model(data, user);

                await new DeleteRouteCommandValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _uow.UsersRepository.Remove(user);
                await _uow.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
