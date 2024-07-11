using CustomerAPI.ApplicationCore.Interface.Service;
using CustomerAPI.ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync depo)
        {
            customerServiceAsync = depo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerServiceAsync.GetAllCustomer());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model)
        {
            var result = await customerServiceAsync.InsertCustomer(model);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await customerServiceAsync.DeleteCustomer(id);
            if(result == -1)
            {
                return NotFound(new {Message="Cannot find that customer,cannot delete."});

            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await customerServiceAsync.GetCustomerById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(CustomerRequestModel model)
        {
            return Ok(await customerServiceAsync.UpdateCustomer(model));
        }

    }
}
