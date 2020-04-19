namespace TrainsOnline.Application.Handlers.StationHandlers.Commands.UpdateStation
{
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateStationeCommandValidator : AbstractValidator<UpdateStationeCommandValidator.Model>
    {
        public UpdateStationeCommandValidator(IPKPAppDbUnitOfWork uow)
        {

        }

        public class Model
        {
            public UpdateStationRequest Data { get; set; }
            public Station Station { get; set; }

            public Model(UpdateStationRequest data, Station station)
            {
                Data = data;
                Station = station;
            }
        }
    }
}
