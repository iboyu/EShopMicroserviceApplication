using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Interfaces.Repository;
using ProductAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Repository
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ProductDbContext db) : base(db)
        {
        }
    }
}
