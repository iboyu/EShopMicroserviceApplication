﻿using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<int> SaveAddress(Address address);
        Task<int> UpdateAddress(Address address);
        Task<int> DeleteAddress(int Id);
        Task<Address> GetAddress(int Id);
        Task<IEnumerable<Address>> GetAddressByCustomerId(int customerId);
    }
}