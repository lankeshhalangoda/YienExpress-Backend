using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Data_DbContext _db;
        public CustomersController(Data_DbContext db) 
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var data=await _db.Customers.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] Customers customer)
        {
            customer.Id=Guid.NewGuid();
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCustomers([FromRoute] Guid id, Customers updatedCustomers)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Name = updatedCustomers.Name;
            customer.Gender = updatedCustomers.Gender;
            customer.Address = updatedCustomers.Address;
            customer.PhoneNo = updatedCustomers.PhoneNo;
            customer.Age = updatedCustomers.Age;
            customer.City = updatedCustomers.City;

            await _db.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
