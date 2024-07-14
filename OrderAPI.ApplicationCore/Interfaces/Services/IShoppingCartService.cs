using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> GetShoppingCartByCustomerId(int Id, Guid customerId);
        Task<int> SaveShoppingCart(ShoppingCartViewModel shoppingCart);
        Task<int> DeleteShoppingCart(int Id, Guid customerId);
        Task<ShoppingCartViewModel> GetShoppingCartByCustomerId(Guid customerId);
    }
}
