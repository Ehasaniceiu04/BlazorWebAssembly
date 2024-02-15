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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customers = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customer model)
        {
            _context.Customers.Update(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
