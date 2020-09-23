using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransfers.Data.Repositories
{
    /// <summary>
    /// Обобщенный репозиторий с реализацией стандартных CRUD операций
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _applicationDbContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _applicationDbContext.AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _applicationDbContext.Update(entity);
                await _applicationDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Remove)} entity must not be null");
            }
            
            try
            {
                _applicationDbContext.Remove(entity);
                _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be removed");
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(RemoveRange)} entity must not be null");
            }
            
            try
            {
                _applicationDbContext.RemoveRange(entities);
                _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be removed");
            }
        }
    }
}