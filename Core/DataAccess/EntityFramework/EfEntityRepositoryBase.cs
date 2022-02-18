using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()   
    {
        public async Task Add(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var addedEntity =   context.Entry(entity); //set the reference address.
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();

            }
        }

        public async Task Delete(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
             
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter); //set the entity on the address, then bring it.
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(TContext context = new TContext())
            {
                return filter == null   //SETTLE ON THE TContext table then bring all or just filtered values.
                    ? await context.Set<TEntity>().ToListAsync() 
                    : await context .Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
