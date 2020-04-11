﻿namespace TrainsOnline.Application.CommonDTO
{
    using System;

    public class IdRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public IdRequest()
        {

        }

        public IdRequest(Guid id)
        {
            Id = id;
        }
    }
}