using TrainsOnline.Application.Common.Interfaces.Repository;
using TrainsOnline.Application.Interfaces.UoW;

namespace TrainsOnline.Application.Common.Interfaces.UoW
{
    using Application.Common.Interfaces.Repository;
    using Application.Interfaces.UoW;

    public interface IMainDbUnitOfWork : IGenericUnitOfWork
    {
        IUsersRepository UsersRepository { get; }
    }
}

