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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagedNotes(long id, BikeDTO bikeDTO)
        {
            if (id != bikeDTO.ID)
            {
                return BadRequest();
            }

            Bike bike = await _context.Bikes.FindAsync(id);

            if (managedNotes == null)
            {
                return NotFound();

            }

            managedNotes.IsComplete = managedNotesDTO.IsComplete;
            managedNotes.Name = managedNotesDTO.Name;

            _context.Entry(managedNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagedNotesExists(id))
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
        public void Delete(int id)
        {
        }
    }
}
