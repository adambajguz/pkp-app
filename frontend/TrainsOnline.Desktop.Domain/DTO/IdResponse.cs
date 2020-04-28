﻿namespace TrainsOnline.Application.DTO
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