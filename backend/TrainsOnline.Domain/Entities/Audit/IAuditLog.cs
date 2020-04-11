using TrainsOnline.Domain.Enums;

namespace TrainsOnline.Domain.Entities.Audit
{
    using System;
    using Domain.Enums;

    public interface IAuditLog
    {
        string TableName { get; set; }
        Guid Key { get; set; }
        AuditActions Action { get; set; }
        string? Values { get; set; }
    }
}
