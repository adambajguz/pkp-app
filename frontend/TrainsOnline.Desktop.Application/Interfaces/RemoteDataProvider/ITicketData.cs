﻿namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.DTO;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.ValueObjects.TicketComponents;

    public interface ITicketData
    {
        //\Task<Guid> CreateTicket(NewTicket data);
        //\Task<TicketDetailsValueObject> GetTicket(Guid id);
        //\Task<TicketDocumentValueObject> GetTicketDocument(Guid id);
        //\Task<IList<TicketDetailsValueObject>> GetCurrentUserTickets();

        Task<Guid> CreateTicket(CreateTicketRequest data);
        Task<GetTicketDetailsResponse> GetTicket(Guid id);
        Task<GetTicketDocumentResponse> GetTicketDocument(Guid id);
        Task<GetUserTicketsListResponse> GetCurrentUserTickets();
    }
}