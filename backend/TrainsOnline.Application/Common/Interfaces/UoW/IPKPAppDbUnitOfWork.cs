namespace TrainsOnline.Application.Common.Interfaces.UoW
{
    using Application.Common.Interfaces.Repository;
    using Application.Interfaces.UoW;

    public interface IPKPAppDbUnitOfWork : IGenericUnitOfWork
    {
        IUsersRepository UsersRepository { get; }
    }
}

