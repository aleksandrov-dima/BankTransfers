﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransfers.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
        
        void Remove(TEntity entity);
        
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}