using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<int> SaveCustomer(CustomerViewModel entity);
        Task<int> UpdateCustomer(CustomerViewModel entity);
        Task<int> DeleteCustomer(Guid customerId);
        Task<CustomerViewModel> GetCustomerById(Guid customerId);
    }
}
