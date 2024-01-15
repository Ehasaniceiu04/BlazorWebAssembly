using Blazor.WASM.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.WASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}
