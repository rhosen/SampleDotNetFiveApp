using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleDotNetFiveApp.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ApiContext _context;

        protected GenericRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
