using DomainModels.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainModels.Repositories
{
    public class AsyncRespository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected readonly DbContext Context;

        #endregion

        #region Contructor

        public AsyncRespository(DbContext context)
        {
            this.Context = context;
        }

        #endregion

        #region Context

        public TContext DbContext<TContext>() where TContext : DbContext
        {
            return this.Context as TContext;
        }

        #endregion

        public async Task<TEntity> GetById(int id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetById(string id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                query = includes.Aggregate(query, (c, include) => c.Include(include));
            }
            return await query.ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<TEntity> AddAndReturn(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
            await this.Context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRange(IEnumerable<TEntity> entityList)
        {
            this.Context.Set<TEntity>().AddRange(entityList);
            await this.Context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            this.Context.Set<TEntity>().Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
        }

        public async Task UpdateEntity(TEntity entitySource, TEntity entityDestiny)
        {
            this.Context.Entry(entityDestiny).CurrentValues.SetValues(entitySource);
            await this.Context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateKeyAndReturn(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            var exist = await this.Context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                this.Context.Entry(exist).CurrentValues.SetValues(entity);
                await this.Context.SaveChangesAsync();
            }
            return exist;
        }

        public async Task Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Attach(entity);
            this.Context.Set<TEntity>().Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAndReturn(TEntity entity)
        {
            this.Context.Set<TEntity>().Attach(entity);
            this.Context.Set<TEntity>().Remove(entity);
            return await this.Context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<TEntity> entityList)
        {
            var entities = entityList.ToList();
            foreach (var entity in entities)
            {
                this.Context.Set<TEntity>().Attach(entity);
            }
            this.Context.Set<TEntity>().RemoveRange(entities);
            await this.Context.SaveChangesAsync();
        }

        public void Attach(TEntity entity)
        {
            this.Context.Set<TEntity>().Attach(entity);
        }

        public Task<IQueryable<TEntity>> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Count()
        {
            return await this.Context.Set<TEntity>().CountAsync();
        }

    }
}
