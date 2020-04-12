namespace TrainsOnline.Application.Common.Interfaces
{
    using Application.Interfaces;
    using Domain.Entities;
    using Domain.Entities.Audit;
    using Microsoft.EntityFrameworkCore;

    public interface IPKPAppDbContext : IGenericDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<EntityAuditLog> EntityAuditLogs { get; set; }
    }
}
