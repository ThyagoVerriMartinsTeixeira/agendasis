using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaSis.Infra.Repositorios
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly MeuContexto contexto;
        private readonly DbSet<TEntity> _db;

        public GenericRepository(MeuContexto dbContext)
        {
            contexto = dbContext;
            _db = contexto.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity, bool saveChanges = true)
        {
            await _db.AddAsync(entity);

            await SaveChangesAsync(saveChanges);
        }

        public async Task DeleteAsync(int id, bool saveChanges = true)
        {
            var dbEntity = await _db.FirstOrDefaultAsync(f => f.Id == id);
            if (dbEntity == null)
            {
                throw new Exception($"Entidade não encontrada com o id: {id}");
            }

            _db.Remove(dbEntity);

            await SaveChangesAsync(saveChanges);
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Where(predicate).AsNoTracking();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.AsNoTracking();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChangesAsync(bool confirm = true)
        {
            if (confirm)
            {
                await contexto.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            contexto.Entry(entity).State = EntityState.Modified;
            //_db.Update(entity);

            await SaveChangesAsync(saveChanges);
        }
    }
}
