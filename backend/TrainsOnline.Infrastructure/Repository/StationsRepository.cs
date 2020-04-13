namespace TrainsOnline.Infrastructure.Repository
{
    using Application.Interfaces;
    using AutoMapper;
    using TrainsOnline.Application.Interfaces.Repository;
    using TrainsOnline.Domain.Entities;

    public class StationsRepository : GenericRepository<Station>, IStationsRepository
    {
        public StationsRepository(IDataRightsService dataRightsService, IPKPAppDbContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }
    }
}
