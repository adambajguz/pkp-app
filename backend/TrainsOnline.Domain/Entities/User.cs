using TrainsOnline.Domain.Entities.Audit;
using TrainsOnline.Domain.Entities.Base;

namespace TrainsOnline.Domain.Entities
{
    using System;
    using Domain.Entities.Audit;
    using Domain.Entities.Base;

    public class User : IBaseEntity, IEntityInfo, IAuditableEntitiy
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        [AuditIgnore]
        public string Password { get; set; } = default!;

        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsAdmin { get; set; }
    }
}
