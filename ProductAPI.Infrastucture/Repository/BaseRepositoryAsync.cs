using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using ProductAPI.ApplicationCore.Interfaces.Repository;
using ProductAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ProductDbContext dbContext;

        public BaseRepositoryAsync(ProductDbContext db)
        {
            dbContext = db;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            dbContext.Set<T>().Remove(result);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);

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
