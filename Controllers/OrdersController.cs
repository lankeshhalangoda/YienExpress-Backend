using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Data_DbContext _db;
        public OrdersController(Data_DbContext  db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task< IActionResult> GetAllOrders()
        {

           var data=await _db.Orders.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrders([FromBody] Orders order)
        {
            order.Id=Guid.NewGuid();    
            await _db.Orders.AddAsync(order);
           await _db.SaveChangesAsync();  

            return Ok(order);    
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOrder([FromRoute] Guid id)
        {
            var order=await _db.Orders.FirstOrDefaultAsync(x=>x.Id==id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateOrders([FromRoute] Guid id,Orders updatedOrders)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Name = updatedOrders.Name;
            order.Address = updatedOrders.Address;
            order.Status = updatedOrders.Status;
            order.PhoneNo = updatedOrders.PhoneNo;
            order.ParcelName = updatedOrders.ParcelName;

            await _db.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
