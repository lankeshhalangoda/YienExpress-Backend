using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly Data_DbContext _db;
        public CouriersController(Data_DbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCouriers()
        {
            var data = await _db.Couriers.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCouriers([FromBody] Couriers courier)
        {
            courier.Id = Guid.NewGuid();
            await _db.Couriers.AddAsync(courier);
            await _db.SaveChangesAsync();
            return Ok(courier);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCourier([FromRoute] Guid id)
        {
            var courier = await _db.Couriers.FirstOrDefaultAsync(x => x.Id == id);
            if (courier == null)
            {
                return NotFound();
            }

            return Ok(courier);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCouriers([FromRoute] Guid id, Couriers updatedCouriers)
        {
            var courier = await _db.Couriers.FirstOrDefaultAsync(x => x.Id == id);
            if (courier == null)
            {
                return NotFound();
            }
            courier.CourierName = updatedCouriers.CourierName;
            courier.Address = updatedCouriers.Address;
            courier.Continent= updatedCouriers.Continent;
            courier.PhoneNo = updatedCouriers.PhoneNo;

            await _db.SaveChangesAsync();
            return Ok(courier);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCourier([FromRoute] Guid id)
        {
            var courier = await _db.Couriers.FirstOrDefaultAsync(x => x.Id == id);
            if (courier == null)
            {
                return NotFound();
            }
            _db.Couriers.Remove(courier);
            await _db.SaveChangesAsync();
            return Ok(courier);
        }
    }
}

