using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Interfaces.Service;
using ProductAPI.ApplicationCore.Models.Request;
using ProductAPI.Infrastructure.Service;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync depo)
        {
            productServiceAsync = depo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productServiceAsync.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var result = await productServiceAsync.InsertProductAsync(model);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await productServiceAsync.GetProductByIdAsync(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productServiceAsync.GetProductByIdAsync(id);
            if(result != null)
            {
                return Ok(await productServiceAsync.DeleteProductAsync(id));
            }
            return NotFound();
        }

    }
}
