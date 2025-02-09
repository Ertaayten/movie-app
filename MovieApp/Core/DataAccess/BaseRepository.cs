using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MovieApp.Core.DataAccess
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
       where TEntity : BaseEntity, new()
       where TContext : DbContext
    {
        private readonly TContext _context;
        public BaseRepository(TContext context)
        {
            _context = context;
        }
        public async Task Add(TEntity entity)
        {
            if (entity.Id == null)
            {
                entity.Id = Guid.NewGuid();
            }
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = Get(x => x.Id == id);
            if (entity == null) 
            {
                throw new Exception("Verilen id'ye ait entity bulunamadı");
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task Update(TEntity entity, Guid id)
        {
            entity.UpdatedAt = DateTime.Now;
            var updatedEntity = Get(x => x.Id == id);

            if (updatedEntity == null) 
            {
                throw new Exception("Verilen id'ye ait entity bulunamadı");
            }
            entity.CreatedAt = updatedEntity.CreatedAt;

            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }
    }
}
