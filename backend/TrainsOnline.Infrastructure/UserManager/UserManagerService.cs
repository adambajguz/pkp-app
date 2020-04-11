namespace TrainsOnline.Infrastructure.UserManager
{
    using Application.Common.Interfaces;

    public class UserManagerService : IUserManagerService
    {
        public UserManagerService()
        {

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
