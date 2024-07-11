﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAPI.ApplicationCore.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter);
    }
}
