namespace TrainsOnline.Infrastructure.CurrentUser
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }

        public string? UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
