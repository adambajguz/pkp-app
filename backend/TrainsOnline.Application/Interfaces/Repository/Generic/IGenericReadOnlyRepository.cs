namespace TrainsOnline.Application.Interfaces.Repository.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using TrainsOnline.Domain.Abstractions.Base;

    public interface IGenericReadOnlyRepository
    {

    }

    public interface IGenericReadOnlyRepository<TEntity> : IGenericReadOnlyRepository
        where TEntity : class, IBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity> GetOneAsync(
        Expression<Func<TEntity, bool>>? filter = null);

        Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default);
        Task<TEntity> NoTrackigFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> NoTrackigFirstOrDefaultAsync(CancellationToken cancellationToken = default);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> GetByIdWithRelatedAsync<TProperty>(Guid id, Expression<Func<TEntity, TProperty>> relatedSelector0);
        Task<TEntity> GetByIdWithRelatedAsync<TProperty>(Guid id, Expression<Func<TEntity, TProperty>> relatedSelector0,
                                                                  Expression<Func<TEntity, TProperty>> relatedSelector1);
        Task<TEntity> GetByIdWithRelatedAsync<TProperty>(Guid id, Expression<Func<TEntity, TProperty>> relatedSelector0,
                                                                  Expression<Func<TEntity, TProperty>> relatedSelector1,
                                                                  params Expression<Func<TEntity, TProperty>>[] relatedSelectors);
        Task<TEntity> NoTrackigGetByIdAsync(Guid id);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<IList<T>> ProjectTo<T>(Expression<Func<TEntity, bool>>? filter = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                    CancellationToken cancellationToken = default);
    }
}
