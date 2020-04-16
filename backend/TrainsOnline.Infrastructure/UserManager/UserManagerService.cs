namespace TrainsOnline.Infrastructure.UserManager
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using TrainsOnline.Application.Helpers;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Domain.Entities;

    public class UserManagerService : IUserManagerService
    {
        private readonly PasswordHasher _passwordHasher = new PasswordHasher();

        public UserManagerService()
        {

        }

        public async Task<User> SetPassword(User user, string? password, CancellationToken cancellationToken = default)
        {
            await new PasswordValidator().ValidateAndThrowAsync(password, cancellationToken: cancellationToken);

            user.Password = _passwordHasher.CreateHash(password!);

            return user;
        }

        public async Task<bool> ValidatePassword(User user, string? password, CancellationToken cancellationToken = default)
        {
            await new PasswordValidator().ValidateAndThrowAsync(password, cancellationToken: cancellationToken);

            return _passwordHasher.ValidatePassword(password!, user.Password);
        }

        //public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = userName,
        //        Email = userName,
        //    };

        //    var result = await _userManager.CreateAsync(user, password);

        //    return (result.ToApplicationResult(), user.Id);
        //}

        //public async Task<Result> DeleteUserAsync(string userId)
        //{
        //    var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        //    if (user != null)
        //    {
        //        return await DeleteUserAsync(user);
        //    }

        //    return Result.Success();
        //}


        //public async Task<Result> DeleteUserAsync(ApplicationUser user)
        //{
        //    var result = await _userManager.DeleteAsync(user);

        //    return result.ToApplicationResult();
        //}
    }
}
