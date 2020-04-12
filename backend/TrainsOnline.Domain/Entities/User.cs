namespace TrainsOnline.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Domain.Abstractions.Audit;
    using TrainsOnline.Domain.Abstractions.Base;

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

        public ICollection<Ticket> Tickets { get; set; } = default!;
    }
}
