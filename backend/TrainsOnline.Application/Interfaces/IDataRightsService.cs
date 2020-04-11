namespace TrainsOnline.Application.Interfaces
{
    using System;
    using System.Linq.Expressions;

    public interface IDataRightsService
    {
        string[] GetRolesFromContext();
        Guid? GetUserIdFromContext();

        bool ContextHasRole(string role);
        bool ContextIsAdmin();

        void ValidateUserId(Guid userIdToValidate);
        void ValidateUserId<T>(T model, Expression<Func<T, Guid>> userIdFieldExpression) where T : class;
        void ValidateHasRole(string role);
        void ValidateIsAdmin();
    }
}
