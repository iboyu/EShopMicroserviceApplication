using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<int> SaveShoppingCart(ShoppingCart shoppingCart);
        Task<int> DeleteShoppingCart(int shoppingCartId, Guid customerId);
        Task<ShoppingCart> GetShoppingCart(int shoppingCartId, Guid customerId);
        Task<ShoppingCart> GetShoppingCart(Guid customerId);
    }
}
