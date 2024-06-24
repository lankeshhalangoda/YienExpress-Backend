using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Data_DbContext _db;
        public EmployeesController(Data_DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {

            var data = await _db.Employees.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] Employees employee)
        {
            employee.Id = Guid.NewGuid();
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployees([FromRoute] Guid id, Employees updatedEmployees)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Company = updatedEmployees.Company;
            employee.Country = updatedEmployees.Country;
            employee.Name = updatedEmployees.Name;
            employee.PhoneNo= updatedEmployees.PhoneNo;
            employee.City = updatedEmployees.City;

            await _db.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
