namespace TrainsOnline.Application.Handlers.StationHandlers.Commands.DeleteStation
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.DTO;

    public class DeleteStationCommandValidator : AbstractValidator<DeleteStationCommandValidator.Model>
    {
        public DeleteStationCommandValidator()
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                Station stationResult = request.Station;
                if (stationResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }

        public class Model
        {
            public IdRequest Data { get; set; }
            public Station Station { get; set; }

            public Model(IdRequest data, Station station)
            {
                Data = data;
                Station = station;
            }
        }
    }
}
