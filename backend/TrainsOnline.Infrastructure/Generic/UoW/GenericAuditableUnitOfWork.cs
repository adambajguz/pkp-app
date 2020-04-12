namespace TrainsOnline.Infrastructure.UoW
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Application.Interfaces.Repository;
    using Application.Interfaces.UoW;
    using AutoMapper;
    using Infrastructure.Repository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Newtonsoft.Json;
    using TrainsOnline.Domain.Abstractions.Audit;
    using TrainsOnline.Domain.Abstractions.Enums;
    using TrainsOnline.Domain.Entities.Audit;

    public abstract class GenericAuditableUnitOfWork : GenericUnitOfWork, IGenericAuditableUnitOfWork
    {
        private IEntityAuditLogRepository? _entityAuditLogRepository;

        public IEntityAuditLogRepository EntityAuditLogRepository => _entityAuditLogRepository ?? (_entityAuditLogRepository = GetSpecificRepository<IEntityAuditLogRepository, EntityAuditLogRepository>());


        public GenericAuditableUnitOfWork(IDataRightsService dataRightsService, IGenericDatabaseContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }

        public override int SaveChanges()
        {
            OnBeforeSaveChanges();

            return _Context.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();

            return await _Context.SaveChangesAsync(cancellationToken);
        }

        //https://www.meziantou.net/entity-framework-core-history-audit-table.htm
        private void OnBeforeSaveChanges()
        {
            _Context.ChangeTracker.DetectChanges();

            IEnumerable<EntityEntry> entries = _Context.ChangeTracker.Entries();
            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity is IAuditableEntitiy == false || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                AuditEntry auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Metadata.GetDefaultTableName()
                };

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.Action = AuditActions.Added;
                        break;
                    case EntityState.Deleted:
                        auditEntry.Action = AuditActions.Deleted;
                        break;
                    case EntityState.Modified:
                        auditEntry.Action = AuditActions.Modified;
                        break;
                }

                foreach (PropertyEntry property in entry.Properties)
                {
                    IProperty metadata = property.Metadata;
                    if (metadata.IsPrimaryKey())
                    {
                        auditEntry.Key = (Guid)property.CurrentValue;

                        if (entry.State == EntityState.Added)
                            auditEntry.NewValues[metadata.Name] = property.CurrentValue;

                        continue;
                    }

                    if (property.IsModified || entry.State == EntityState.Added)
                    {
                        object[] x = metadata.PropertyInfo.GetCustomAttributes(typeof(AuditIgnoreAttribute), false);

                        if (x.Length == 0)
                            auditEntry.NewValues[metadata.Name] = property.CurrentValue;
                    }
                }

                if (auditEntry.NewValues.Count > 0 || auditEntry.Action != AuditActions.Modified)
                {
                    EntityAuditLogRepository.Add(auditEntry.ToAudit());
                }
            }
        }

        private class AuditEntry
        {
            public AuditEntry(EntityEntry entry)
            {
                Entry = entry;
            }

            public EntityEntry Entry { get; } = default!;
            public string TableName { get; set; } = default!;
            public Guid Key { get; set; } = default!;
            public AuditActions Action { get; set; }
            public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

            public EntityAuditLog ToAudit()
            {
                EntityAuditLog audit = new EntityAuditLog
                {
                    TableName = TableName,
                    Key = Key,
                    Action = Action,
                    Values = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues)
                };
                return audit;
            }
        }
    }
}