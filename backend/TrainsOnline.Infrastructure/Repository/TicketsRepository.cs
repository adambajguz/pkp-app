namespace TrainsOnline.Infrastructure.Repository
{
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.Repository;
    using Application.Interfaces;
    using AutoMapper;
    using TrainsOnline.Domain.Entities;

    public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
    {
        public TicketsRepository(IDataRightsService dataRightsService, IPKPAppDbContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }
    }
}
