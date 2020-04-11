namespace TrainsOnline.Application.Interfaces.Repository.Generic
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities.Base;

    public interface IGenericRepository<TEntity> : IGenericReadOnlyRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        Task Remove(Guid id);

        void Remove(TEntity entity);
    }
}