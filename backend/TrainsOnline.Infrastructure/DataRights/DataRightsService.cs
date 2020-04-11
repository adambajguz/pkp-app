namespace TrainsOnline.Infrastructure.DataRights
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using Application.Exceptions;
    using Application.Interfaces;
    using TrainsOnline.Domain.Content.Jwt;
    using Microsoft.AspNetCore.Http;

    //TODO use expressions to validate datarights
    public class DataRightsService : IDataRightsService
    {
        private readonly IHttpContextAccessor _context;

        public DataRightsService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Guid? GetUserIdFromContext()
        {
            ClaimsIdentity? identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            Claim? claim = identity?.FindFirst(ClaimTypes.UserData);

            return claim == null ? null : (Guid?)Guid.Parse(claim.Value);
        }

        public string[] GetRolesFromContext()
        {
            ClaimsIdentity? identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            string[] roles = identity?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToArray() ?? new string[] { };

            return roles;
        }

        public bool ContextHasRole(string role)
        {
            if (!Roles.IsValidRole(role))
                return false;

            ClaimsIdentity? identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            Claim? result = identity?.FindAll(ClaimTypes.Role).Where(x => x.Value == role).FirstOrDefault();

            return result != null;
        }

        public bool ContextIsAdmin()
        {
            return ContextHasRole(Roles.Admin);
        }

        public void ValidateUserId<T>(T model, Expression<Func<T, Guid>> userIdFieldExpression) where T : class
        {
            if (ContextIsAdmin())
                return;

            Func<T, Guid> func = userIdFieldExpression.Compile();
            Guid dataUserId = func(model);

            Guid? userId = GetUserIdFromContext();
            if (userId == null || dataUserId != userId)
                throw new ForbiddenException();
        }

        public void ValidateUserId(Guid userIdToValidate)
        {
            if (ContextIsAdmin())
                return;

            Guid? userId = GetUserIdFromContext();
            if (userId == null || userIdToValidate != userId)
                throw new ForbiddenException();
        }

        public void ValidateIsAdmin()
        {
            ValidateHasRole(Roles.Admin);
        }

        public void ValidateHasRole(string role)
        {
            if (!Roles.IsValidRole(role))
                throw new ForbiddenException();

            ClaimsIdentity? identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            Claim? result = identity?.FindAll(ClaimTypes.Role).Where(x => x.Value == role).FirstOrDefault();

            if (result == null)
                throw new ForbiddenException();
        }
    }
}
