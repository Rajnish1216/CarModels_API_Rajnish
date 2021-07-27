﻿using System;
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
    public class CarBrandAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarBrandAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarBrandAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarBrand>>> GetCarBrands()
        {
            return await _context.CarBrands.ToListAsync();
        }

        // GET: api/CarBrandAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarBrand>> GetCarBrand(int id)
        {
            var carBrand = await _context.CarBrands.FindAsync(id);

            if (carBrand == null)
            {
                return NotFound();
            }

            return carBrand;
        }

        // PUT: api/CarBrandAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarBrand(int id, CarBrand carBrand)
        {
            if (id != carBrand.ID)
            {
                return BadRequest();
            }

            _context.Entry(carBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBrandExists(id))
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

        // POST: api/CarBrandAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarBrand>> PostCarBrand(CarBrand carBrand)
        {
            _context.CarBrands.Add(carBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarBrand", new { id = carBrand.ID }, carBrand);
        }

        // DELETE: api/CarBrandAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarBrand>> DeleteCarBrand(int id)
        {
            var carBrand = await _context.CarBrands.FindAsync(id);
            if (carBrand == null)
            {
                return NotFound();
            }

            _context.CarBrands.Remove(carBrand);
            await _context.SaveChangesAsync();

            return carBrand;
        }

        private bool CarBrandExists(int id)
        {
            return _context.CarBrands.Any(e => e.ID == id);
        }
    }
}
