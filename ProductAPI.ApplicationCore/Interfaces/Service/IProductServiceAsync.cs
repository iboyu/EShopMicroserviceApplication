using ProductAPI.ApplicationCore.Models.Reponse;
using ProductAPI.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Interfaces.Service
{
    public interface IProductServiceAsync
    {
        public Task<int> InsertProductAsync(ProductRequestModel product);
        public Task<int> UpdateProductAsync(ProductRequestModel product, int id);
        public Task<int> DeleteProductAsync(int id);
        public Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
        public Task<ProductResponseModel> GetProductByIdAsync(int Id);
    }
}
