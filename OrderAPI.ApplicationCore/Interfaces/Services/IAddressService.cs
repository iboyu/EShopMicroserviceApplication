using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IAddressService
    {
        Task<int> SaveAddress(AddressViewModel address);
        Task<int> UpdateAddress(AddressViewModel address);
        Task<int> DeleteAddress(int Id);
        Task<AddressViewModel> GetAddress(int Id);
        Task<IEnumerable<AddressViewModel>> GetAddressByCustomerId(int customerId);
    }
}
