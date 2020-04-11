using TrainsOnline.Application.Interfaces.Repository;

namespace TrainsOnline.Application.Interfaces.UoW
{
    using Application.Interfaces.Repository;

    public interface IGenericAuditableUnitOfWork : IGenericUnitOfWork
    {
        IEntityAuditLogRepository EntityAuditLogRepository { get; }
    }
}
