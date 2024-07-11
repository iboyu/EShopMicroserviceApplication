using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Interface.Repository;
using CustomerAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Repository
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        public CustomerRepositoryAsync(EShopDbContext db):base(db)
        {
            
        }
    }
}
