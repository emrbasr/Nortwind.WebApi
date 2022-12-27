using Microsoft.AspNetCore.Mvc;
using Nortwind.WebApi.Entities;

namespace Nortwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindContext context;

        public CustomerController(NorthwindContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = context.Customers.ToList();
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
