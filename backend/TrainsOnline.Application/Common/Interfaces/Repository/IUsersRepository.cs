namespace TrainsOnline.Application.Common.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Application.Interfaces.Repository.Generic;
    using Domain.Entities;

    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<bool> IsEmailInUseAsync(string email);
        Task<bool> IsUserNameInUseAsync(string userName);
        Task<bool> IsEmailOrUserNameInUseAsync(string email, string userName);
    }
}
