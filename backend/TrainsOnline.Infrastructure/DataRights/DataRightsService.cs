namespace TrainsOnline.Infrastructure.DataRights
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Application.Exceptions;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;
    using TrainsOnline.Domain.Jwt;

    //TODO use expressions to validate datarights
    public class DataRightsService : IDataRightsService
    {
        private readonly IHttpContextAccessor _context;
        private readonly IPKPAppDbUnitOfWork _uow;

        public DataRightsService(IHttpContextAccessor context, IPKPAppDbUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
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

        public async Task ValidateUserId<T>(T model, Expression<Func<T, Guid>> userIdFieldExpression) where T : class
        {
            if (ContextIsAdmin())
                return;

            Func<T, Guid> func = userIdFieldExpression.Compile();
            Guid dataUserId = func(model);

            await ValidateUserId(dataUserId);
        }

        public async Task ValidateUserId(Guid userIdToValidate)
        {
            if (ContextIsAdmin())
                return;

            Guid? userId = GetUserIdFromContext();
            if (userId == null || userIdToValidate != userId)
                throw new ForbiddenException();

            User user = await _uow.UsersRepository.GetByIdAsync(userIdToValidate);
            if (user is null)
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
