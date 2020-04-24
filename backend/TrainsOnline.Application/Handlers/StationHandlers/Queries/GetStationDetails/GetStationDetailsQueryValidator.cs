namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetStationDetailsQueryValidator : AbstractValidator<IdRequest>
    {
        public GetStationDetailsQueryValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Id).NotEmpty().MustAsync(async (request, val, token) =>
            {
                Station stationResults = await uow.StationsRepository.GetByIdAsync(request.Id);
                if (stationResults == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.General.IsIncorrectId);
        }
    }
}
