using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarModels_API_Rajnish.Data;
using CarModels_API_Rajnish.Models;

namespace CarModels_API_Rajnish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCategoryAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarCategoryAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarCategoryAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCategory>>> GetCarCategories()
        {
            return await _context.CarCategories.ToListAsync();
        }

        // GET: api/CarCategoryAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCategory>> GetCarCategory(int id)
        {
            var carCategory = await _context.CarCategories.FindAsync(id);

            if (carCategory == null)
            {
                return NotFound();
            }

            return carCategory;
        }

        // PUT: api/CarCategoryAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCategory(int id, CarCategory carCategory)
        {
            if (id != carCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(carCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarCategoryAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarCategory>> PostCarCategory(CarCategory carCategory)
        {
            _context.CarCategories.Add(carCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarCategory", new { id = carCategory.ID }, carCategory);
        }

        // DELETE: api/CarCategoryAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarCategory>> DeleteCarCategory(int id)
        {
            var carCategory = await _context.CarCategories.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }

            _context.CarCategories.Remove(carCategory);
            await _context.SaveChangesAsync();

            return carCategory;
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategories.Any(e => e.ID == id);
        }
    }
}
