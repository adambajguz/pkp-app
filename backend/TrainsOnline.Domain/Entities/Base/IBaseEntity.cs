namespace TrainsOnline.Domain.Entities.Base
{
    using System;

    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}