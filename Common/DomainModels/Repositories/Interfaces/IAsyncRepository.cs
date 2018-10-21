using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DomainModels.Model;

namespace DomainModels.Repositories.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> SelectIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<int> Add(TEntity entity);

        Task<TEntity> AddAndReturn(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entityList);

        Task<int> Update(TEntity entity);

        Task UpdateEntity(TEntity entitySource, TEntity entityDestiny);

        Task<TEntity> UpdateKeyAndReturn(TEntity entity, object key);

        Task<int> Delete(TEntity entity);

        Task<int> DeleteAndReturn(TEntity entity);

        Task DeleteRange(IEnumerable<TEntity> entityList);

        void Attach(TEntity entity);

        Task<IQueryable<TEntity>> GetQueryable();

        Task<int> Count();
    }
}
