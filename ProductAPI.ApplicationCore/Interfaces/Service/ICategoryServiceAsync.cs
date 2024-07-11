using ProductAPI.ApplicationCore.Models.Reponse;
using ProductAPI.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Interfaces.Service
{
    public interface ICategoryServiceAsync
    {
        public Task<int> InsertCategoryAsync(CategoryRequestModel model);
        public Task<int> UpdateCategoryAsync(CategoryRequestModel model, int id);
        public Task<int> DeleteCategoryAsync(int id);
        public Task<IEnumerable<CategoryResponseModel>> GetAllCategoryAsync();
        public Task<CategoryResponseModel> GetCategoryByIdAsync(int Id);

    }
}
