using CustomerAPI.ApplicationCore.Interface.Repository;
using CustomerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T>where T : class
    {
        private readonly EShopDbContext dbContext;

        public BaseRepositoryAsync(EShopDbContext db)
        {
            dbContext = db;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if(result == null)
            {
                return -1;
            }
            dbContext.Set<T>().Remove(result);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<int> InsertAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
    }
}
