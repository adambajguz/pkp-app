namespace TrainsOnline.Infrastructure.UoW
{
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.Repository;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using AutoMapper;
    using TrainsOnline.Infrastructure.Repository;

    public class PKPAppDbUnitOfWork : GenericAuditableUnitOfWork, IPKPAppDbUnitOfWork
    {
        private IRoutesRepository? _routesRepository;
        public IRoutesRepository RoutesRepository => _routesRepository ?? (_routesRepository = GetSpecificRepository<IRoutesRepository, RoutesRepository>());

        private IStationsRepository? _stationsRepository;
        public IStationsRepository StationsRepository => _stationsRepository ?? (_stationsRepository = GetSpecificRepository<IStationsRepository, StationsRepository>());

        private ITicketsRepository? _ticketsRepository;
        public ITicketsRepository TicketsRepository => _ticketsRepository ?? (_ticketsRepository = GetSpecificRepository<ITicketsRepository, TicketsRepository>());

        private IUsersRepository? _usersRepository;
        public IUsersRepository UsersRepository => _usersRepository ?? (_usersRepository = GetSpecificRepository<IUsersRepository, UsersRepository>());

        public PKPAppDbUnitOfWork(IDataRightsService dataRightsService, IPKPAppDbContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }
    }
}
