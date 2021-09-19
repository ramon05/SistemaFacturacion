using Microsoft.EntityFrameworkCore;
using SistemaFacturacionApi.Core.BaseModel;
using SistemaFacturacionApi.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Query();
       Task<TEntity> Get(int id);
       Task<TEntity> Add(TEntity entity);
       Task<TEntity> Update(TEntity entity);
       Task<TEntity> Delete(int id);
    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBase
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _set;

        public BaseRepository(IDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return _set.AsQueryable();
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entity = await Get(id);
            _set.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}
