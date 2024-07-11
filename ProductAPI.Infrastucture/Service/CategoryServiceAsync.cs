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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync CategoryRepositoryAsync;

        public CategoryServiceAsync(ICategoryRepositoryAsync repo)
        {
            CategoryRepositoryAsync = repo;
        }
        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await CategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllCategoryAsync()
        {
            var result = await CategoryRepositoryAsync.GetAllAsync();
            List<CategoryResponseModel> list = new List<CategoryResponseModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    var myProduct = item.Products?.Select(p => new ProductResponseModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        UnitPrice = p.UnitPrice,
                        Quantity = p.Quantity,
                        CategoryId = p.CategoryId
                    }) ?? Enumerable.Empty<ProductResponseModel>();

                    list.Add(new CategoryResponseModel
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName,
                        CategoryDescription = item.CategoryDescription,
                        Products = (IEnumerable<Product>)myProduct
                    });
                }
                return list;
            }
            return null;
            
        }

        public async Task<CategoryResponseModel> GetCategoryByIdAsync(int Id)
        {
            var result = await CategoryRepositoryAsync.GetByIdAsync(Id);
            if (result != null)
            {
                var myProduct = result.Products.Select(p => new ProductResponseModel{ 
                    Id = p.Id,
                    Name = p.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId                
                });
                var model = new CategoryResponseModel
                {
                    Id = result.Id,
                    CategoryName = result.CategoryName,
                    CategoryDescription = result.CategoryDescription
                };
                return model;
            }
            return null;
        }
        public async Task<int> InsertCategoryAsync(CategoryRequestModel model)
        {
            Category c = new Category();
            c.CategoryName = model.CategoryName;
            c.CategoryDescription = model.CategoryDescription;
            return await CategoryRepositoryAsync.InsertAsync(c);
        }

        public async Task<int> UpdateCategoryAsync(CategoryRequestModel model, int id)
        {
            var result = await CategoryRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                var modelResult = new Category
                {
                    CategoryName = result.CategoryName,
                    CategoryDescription = result.CategoryDescription
                };
                return await CategoryRepositoryAsync.UpdateAsync(modelResult);
            }
            else {
                return 0;
            }
        }
    }
}

