namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.ValidateDocument
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class ValidateDocumentQuery : IRequest<bool>
    {
        public IdRequest Data { get; }

        public ValidateDocumentQuery(IdRequest data)
        {
            Data = data;
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
                IdRequest data = request.Data;

                bool ticketExists = await _uow.TicketsRepository.GetExistsAsync(x => x.Id == data.Id);

                return ticketExists;
            }
        }
    }
}
