namespace TrainsOnline.Application.Interfaces
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IDataRightsService
    {
        string[] GetRolesFromContext();
        Guid? GetUserIdFromContext();

        bool ContextHasRole(string role);
        bool ContextIsAdmin();

        Task ValidateUserId(Guid userIdToValidate);
        Task ValidateUserId<T>(T model, Expression<Func<T, Guid>> userIdFieldExpression) where T : class;
        void ValidateHasRole(string role);
        void ValidateIsAdmin();
    }
}
