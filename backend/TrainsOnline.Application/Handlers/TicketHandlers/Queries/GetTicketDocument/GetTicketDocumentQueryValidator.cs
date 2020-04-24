namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetTicketDocumentQueryValidator : AbstractValidator<IdRequest>
    {
        public GetTicketDocumentQueryValidator(IPKPAppDbUnitOfWork uow)
        {
            RuleFor(x => x.Id).NotEmpty().MustAsync(async (request, val, token) =>
            {
                Ticket ticketResults = await uow.TicketsRepository.GetByIdAsync(request.Id);
                if (ticketResults == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.General.IsIncorrectId);
        }
    }
}
