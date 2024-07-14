using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Interfaces.Repositories;
using OrderAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly OrderDbContext _dbContext;
        public ShoppingCartRepository(OrderDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> DeleteShoppingCart(int shoppingCartId, Guid customerId)
        {
            var entity = await _dbContext.ShoppingCart.Where(x => x.Id == shoppingCartId && x.CustomerId == customerId).FirstOrDefaultAsync();
            if (entity == null)
            {
                return 0;
            }

            _dbContext.ShoppingCart.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCart(int shoppingCartId, Guid customerId)
        {
            var entity = await _dbContext.ShoppingCart.Where(x => x.Id == shoppingCartId && x.CustomerId == customerId).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<ShoppingCart> GetShoppingCart(Guid customerId)
        {
            var entity = await _dbContext.ShoppingCart.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<int> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            await _dbContext.ShoppingCart.AddAsync(shoppingCart);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
