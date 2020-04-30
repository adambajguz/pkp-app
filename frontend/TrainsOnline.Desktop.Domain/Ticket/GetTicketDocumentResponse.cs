namespace TrainsOnline.Desktop.Domain.Ticket
{
    using System;
    using TrainsOnline.Desktop.Domain.DTO;

    public class GetTicketDocumentResponse : IDataTransferObject
    {
        public Guid Id { get; set; }

        public byte[] Document { get; set; }
    }
}
