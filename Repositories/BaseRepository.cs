using Microsoft.EntityFrameworkCore;
using TPH.Entities;

namespace TPH.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext applicationDbContext;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IQueryable<TEntity> Query => applicationDbContext.Set<TEntity>().AsNoTracking();

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await applicationDbContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id == id);
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            applicationDbContext.Set<TEntity>().Add(entity);
            await applicationDbContext.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            applicationDbContext.Set<TEntity>().Update(entity);
            await applicationDbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            applicationDbContext.Set<TEntity>().Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
