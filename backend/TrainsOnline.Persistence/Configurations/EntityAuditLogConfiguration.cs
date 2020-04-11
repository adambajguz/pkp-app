namespace TrainsOnline.Persistence.Configurations
{
    using TrainsOnline.Domain.Content.Entities.Audit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EntityAuditLogConfiguration : IEntityTypeConfiguration<EntityAuditLog>
    {
        public void Configure(EntityTypeBuilder<EntityAuditLog> builder)
        {
            builder.Property(x => x.Action).HasConversion<int>();
        }
    }
}
