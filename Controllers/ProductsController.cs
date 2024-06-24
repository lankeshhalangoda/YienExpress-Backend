using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly Data_DbContext _db;
            public ProductsController(Data_DbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllProducts()
            {

                var data = await _db.Products.ToListAsync();
                return Ok(data);
            }

            [HttpPost]
            public async Task<IActionResult> AddProducts([FromBody] Products product)
            {
                product.Id = Guid.NewGuid();
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                return Ok(product);
            }

            [HttpGet]
            [Route("{id:Guid}")]
            public async Task<IActionResult> GetProduct([FromRoute] Guid id)
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }

            [HttpPut]
            [Route("{id:Guid}")]
            public async Task<IActionResult> UpdateProducts([FromRoute] Guid id, Products updatedProducts)
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                product.Name = updatedProducts.Name;
                product.OrderID = updatedProducts.OrderID;
                product.Condition = updatedProducts.Condition;
                product.WeightInGrams = updatedProducts.WeightInGrams;

                await _db.SaveChangesAsync();
                return Ok(product);
            }

            [HttpDelete]
            [Route("{id:Guid}")]
            public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return Ok(product);
            }
        }
    }
