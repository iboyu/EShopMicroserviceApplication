using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Interfaces.Service;
using ProductAPI.ApplicationCore.Models.Request;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync repo)
        {
            categoryServiceAsync = repo;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryServiceAsync.GetAllCategoryAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequestModel model)
        {
            var result = await categoryServiceAsync.InsertCategoryAsync(model);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await categoryServiceAsync.GetCategoryByIdAsync(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await categoryServiceAsync.GetCategoryByIdAsync(id); 
            if(result != null)
            {
                return Ok(await categoryServiceAsync.DeleteCategoryAsync(id));
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult>UpdateById(CategoryRequestModel model, int id)
        {
            var result = await categoryServiceAsync.GetCategoryByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            var updateResult = await categoryServiceAsync.UpdateCategoryAsync(model, id);
            if(updateResult > 0)
            {
                return Ok(updateResult);
            }
            return BadRequest();
        }
    }
}
