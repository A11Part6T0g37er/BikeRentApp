using BikeRentApp.Models;
using BikeRentApp.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BikeRentApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly UnitOfWork _context;

        public BikeController()
        {
            _context = new UnitOfWork();
        }

        // GET: api/<BikeController>
        [HttpGet]
        public IEnumerable<Bike> Get()
        {
            return _context.Bikes.GetAll();
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public  ActionResult<Bike> GetAsync(int id)
        {
            Bike bike = (Bike)_context.Bikes.Find(x=>x.ID == id);

            if (bike == null)
            {
                return NotFound();
            }

            return bike;
        }

        // POST api/<BikeController>
        [HttpPost]
        public async Task<ActionResult<BikeDTO>> PostBike(BikeDTO bikeDTO)
        {
            var bike = new Bike
            {
                IsRented = bikeDTO.IsRented,
                Name = bikeDTO.Name,
                RentPrice= bikeDTO.RentPrice,
                BikeType = bikeDTO.BikeType
            };
            _context.Bikes.Add(bike);
            await _context.Bikes.BikeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = bikeDTO.ID }, bikeDTO);
           
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBike(long id, BikeDTO bikeDTO)
        {
            if (id != bikeDTO.ID)
            {
                return BadRequest();
            }

            Bike bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();

            }

            bike.IsRented = bikeDTO.IsRented;
            bike.Name = bikeDTO.Name;
            bike.RentPrice = bikeDTO.RentPrice;
            
           
            _context.Bikes.BikeContext.Entry(bike).State = EntityState.Modified;

            try
            {
                 _context.Bikes.BikeContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Bike bike =  await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            await _context.Bikes.BikeContext.SaveChangesAsync();

            return NoContent();
        }




        private bool BikeExists(long id) => _context.Bikes.BikeContext.Bikes.Any(x=>x.ID==id);
    }
}
