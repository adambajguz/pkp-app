namespace TrainsOnline.Desktop.Infrastructure.DTO.Ticket
{
    using System;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class GetTicketDocumentResponse : IDataTransferObject
    {
        public Guid Id { get; set; }

        public byte[] Document { get; set; }
    }
}
