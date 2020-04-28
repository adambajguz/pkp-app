namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDocument
{
    using System;
    using TrainsOnline.Application.DTO;

    public class GetTicketDocumentResponse : IDataTransferObject
    {
        public Guid Id { get; set; }

        public byte[] Document { get; set; }
    }
}
