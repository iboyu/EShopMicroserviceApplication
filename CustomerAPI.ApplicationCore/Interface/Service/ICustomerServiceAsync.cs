using CustomerAPI.ApplicationCore.Models.Request;
using CustomerAPI.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Interface.Service
{
    public interface ICustomerServiceAsync
    {
        Task<int> InsertCustomer(CustomerRequestModel model);
        Task<int> DeleteCustomer(int id);
        Task<int> UpdateCustomer(CustomerRequestModel model);
        Task<CustomerResponseModel> GetCustomerById(int id);
        Task<IEnumerable<CustomerResponseModel>> GetAllCustomer();
    }
}
