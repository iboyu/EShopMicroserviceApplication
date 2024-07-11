using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Interfaces.Repository;
using ProductAPI.ApplicationCore.Interfaces.Service;
using ProductAPI.ApplicationCore.Models.Reponse;
using ProductAPI.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepository;

        public ProductServiceAsync(IProductRepositoryAsync depo)
        {
            productRepository = depo;
        }
        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
        {
            var result = await productRepository.GetAllAsync();
            List<ProductResponseModel> products = new List<ProductResponseModel>();
            foreach (var product in result)
            {
                var model = new ProductResponseModel()
                {
                    Quantity = product.Quantity,
                    Id = product.Id,
                    Name = product.Name,
                    UnitPrice = product.UnitPrice,
                    CategoryId = product.CategoryId,
                };
                products.Add(model);
            }
            return products;
        }

        public async Task<ProductResponseModel> GetProductByIdAsync(int Id)
        {
            var result = await productRepository.GetByIdAsync(Id);
            if(result != null)
            {
                ProductResponseModel model = new ProductResponseModel();
                model.Quantity = result.Quantity;
                model.Id = result.Id;
                model.Name = result.Name;
                model.UnitPrice = result.UnitPrice;
                model.CategoryId = result.CategoryId;
                return model;
            }
            return null;
        }

        public async Task<int> InsertProductAsync(ProductRequestModel product)
        {
            var p = new Product(); 
            p.UnitPrice = product.UnitPrice;
            p.Quantity = product.Quantity;
            p.Name = product.Name;
            p.CategoryId = product.CategoryId;
            return await productRepository.InsertAsync(p);
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel product, int id)
        {
            var model = await productRepository.GetByIdAsync(id);
            if(model != null)
            {
                model.Quantity = product.Quantity;
                model.UnitPrice = product.UnitPrice;
                model.Name= product.Name;
                model.CategoryId = product.CategoryId;
                return await productRepository.UpdateAsync(model);
            }
            return 0;
        }
    }
}
