namespace TrainsOnline.Application.CommonDTO
{
    using System;

    public class IdResponse : IDataTransferObject
    {
        public Guid Id { get; set; }

        public IdResponse()
        {

        }

        public IdResponse(Guid id)
        {
            Id = id;
        }
    }
}