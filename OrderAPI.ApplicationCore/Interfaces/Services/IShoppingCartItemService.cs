using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItemViewModel>> GetShoppingCartItemByCustomerId(int CartId);
        Task<int> SaveShoppingCartItem(List<ShoppingCartItemViewModel> shoppingCart);
        Task<int> DeleteShoppingCartItem(int cartId);
        Task<int> DeleteShoppingCartItemById(int ShoppingCarttId);
        Task<int> UpdateShoppingCartItem(ShoppingCartItemViewModel shoppingCart);
    }
}
