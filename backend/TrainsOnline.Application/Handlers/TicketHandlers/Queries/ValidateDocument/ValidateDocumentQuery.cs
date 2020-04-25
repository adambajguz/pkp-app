namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.ValidateDocument
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class ValidateDocumentQuery : IRequest<bool>
    {
        public Guid TId { get; }
        public Guid UId { get; }
        public Guid RId { get; }

        public ValidateDocumentQuery(Guid tid, Guid uid, Guid rid)
        {
            TId = tid;
            UId = uid;
            RId = rid;
        }

        public class Handler : IRequestHandler<ValidateDocumentQuery, bool>
        {
            private readonly IPKPAppDbUnitOfWork _uow;

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<bool> Handle(ValidateDocumentQuery request, CancellationToken cancellationToken)
            {
                Ticket ticket = await _uow.TicketsRepository.GetByIdAsync(request.TId);

                bool isTicketValid = ticket.Id == request.TId &&
                                     ticket.UserId == request.UId &&
                                     ticket.RouteId == request.RId;

                return isTicketValid;
            }
        }
    }
}
