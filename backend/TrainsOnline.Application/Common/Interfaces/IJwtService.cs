namespace TrainsOnline.Application.Common.Interfaces
{
    using System;
    using TrainsOnline.Application.Main.Authentication.Queries.GetValidToken;

    public interface IJwtService
    {
        JwtTokenModel? GenerateJwtToken(string email, Guid id, string[] roles);

        void ValidateStringToken(string token);
        bool IsTokenStringValid(string token);

        Guid GetUserIdFromToken(string token);
        bool IsRoleInToken(string token, string role);
    }
}
