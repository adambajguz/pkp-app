namespace TrainsOnline.Application.Handlers.StationHandlers.Commands.DeleteStation
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class DeleteStationCommand : IRequest
    {
        public IdRequest Data { get; }

        public DeleteStationCommand(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<DeleteStationCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<Unit> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                Station station = await _uow.StationsRepository.GetByIdAsync(data.Id);

                EntityRequestByIdValidator<Station>.Model validationModel = new EntityRequestByIdValidator<Station>.Model(data, station);
                await new EntityRequestByIdValidator<Station>().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _uow.StationsRepository.Remove(station);
                await _uow.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
