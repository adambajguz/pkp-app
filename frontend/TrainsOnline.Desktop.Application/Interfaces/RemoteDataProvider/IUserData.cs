namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.ValueObjects.User;

    public interface IUserData
    {
        bool IsAuthenticated { get; }

        Task<bool> Login(string email, string password);
        void Logout();
        Task<Guid> Register(NewUser data);

        Task<UserDetailsValueObject> GetCurrentUser();
    }
}
