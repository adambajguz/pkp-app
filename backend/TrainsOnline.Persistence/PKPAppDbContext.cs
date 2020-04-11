namespace TrainsOnline.Persistence
{
    using Application.Common.Interfaces;
    using TrainsOnline.Domain.Content.Entities;
    using TrainsOnline.Domain.Content.Entities.Audit;
    using Microsoft.EntityFrameworkCore;

    public class PKPAppDbContext : DbContext, IPKPAppDbContext
    {
        public PKPAppDbContext(DbContextOptions<PKPAppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<EntityAuditLog> EntityAuditLogs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PKPAppDbContext).Assembly);
        }
    }
}
