using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Repositories
{
    public interface IShoppingCartItemRepository
    {
        Task<int> SaveShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task<int> DeleteShoppingCartItem(int cartId);
        Task<int> UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task<ShoppingCartItem> GetShoppingCartItemById(int shoppingCartItemId);
        Task<List<ShoppingCartItem>> GetShoppingCartItemListById(int cartId);
        Task<int> DeleteShoppingCartItemById(int shoppingCartItemId);
    }
}
