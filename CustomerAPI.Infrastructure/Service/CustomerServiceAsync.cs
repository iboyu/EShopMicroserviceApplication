using AutoMapper;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Interface.Repository;
using CustomerAPI.ApplicationCore.Interface.Service;
using CustomerAPI.ApplicationCore.Models.Request;
using CustomerAPI.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Service
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        private readonly IMapper mapper;

        public CustomerServiceAsync(ICustomerRepositoryAsync dp, IMapper mapper)
        {
            customerRepositoryAsync = dp;
            this.mapper = mapper;
        }
        public async Task<int> DeleteCustomer(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomer()
        {
            var result = await customerRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<CustomerResponseModel>>(result);
        }

        public async Task<CustomerResponseModel> GetCustomerById(int id)
        {
            var result = await customerRepositoryAsync.GetByIdAsync(id);
            return mapper.Map<CustomerResponseModel>(result);
        }

        public async Task<int> InsertCustomer(CustomerRequestModel model)
        {
            return await customerRepositoryAsync.InsertAsync(mapper.Map<Customer>(model));
        }

        public async Task<int> UpdateCustomer(CustomerRequestModel model)
        {
            return await customerRepositoryAsync.UpdateAsync(mapper.Map<Customer>(model));
        }
    }
}
