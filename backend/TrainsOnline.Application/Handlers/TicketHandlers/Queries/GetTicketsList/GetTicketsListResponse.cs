namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList
{
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;

    public class GetTicketsListResponse : IDataTransferObject
    {
        public IList<GetTicketDetailResponse> Ticket { get; set; } = default!;
    }
}
