using TrainsOnline.Domain.Entities.Base;
using TrainsOnline.Domain.Enums;

namespace TrainsOnline.Domain.Entities.Audit
{
    using System;
    using Domain.Entities.Base;
    using Domain.Enums;

    public class EntityAuditLog : IBaseEntity, IEntityCreation, IAuditLog
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }

        public string TableName { get; set; } = default!;
        public Guid Key { get; set; } = default!;
        public AuditActions Action { get; set; }
        public string? Values { get; set; }
    }
}
