namespace TrainsOnline.Infrastructure.UoW
{
    using AutoMapper;
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.Repository;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using TrainsOnline.Infrastructure.Main.Repository;

    public class MainDbUnitOfWork : GenericAuditableUnitOfWork, IMainDbUnitOfWork
    {
        private IUsersRepository? _usersRepository;

        public IUsersRepository UsersRepository => _usersRepository ?? (_usersRepository = GetSpecificRepository<IUsersRepository, UsersRepository>());

        public MainDbUnitOfWork(IDataRightsService dataRightsService, IPKPAppDbContext context, IMapper mapper) : base(dataRightsService, context, mapper)
        {

        }
    }
}
