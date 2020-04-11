namespace TrainsOnline.Infrastructure.Repository
{
    using AutoMapper;
    using Application.Interfaces;
    using Application.Interfaces.Repository;
    using TrainsOnline.Domain.Content.Entities.Audit;

    public class EntityAuditLogRepository : GenericRepository<EntityAuditLog>, IEntityAuditLogRepository
    {
        public EntityAuditLogRepository(IDataRightsService dataRightsService, IGenericDatabaseContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }
    }
}
