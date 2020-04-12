namespace TrainsOnline.Application.Common.Interfaces.UoW
{
    using Application.Common.Interfaces.Repository;
    using Application.Interfaces.UoW;

    public interface IPKPAppDbUnitOfWork : IGenericUnitOfWork
    {
        IRoutesRepository RoutesRepository { get; }
        IStationsRepository StationsRepository { get; }
        ITicketsRepository TicketsRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
