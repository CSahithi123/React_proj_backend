using ApiVilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly ApplicationDbContext _amenityContext;
        public AmenityController(ApplicationDbContext amenityContext)
        {
            _amenityContext = amenityContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            if (_amenityContext.Amenities == null)
            {
                return NotFound();
            }
            return await _amenityContext.Amenities.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            if (_amenityContext.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _amenityContext.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return amenity;


        }

        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            _amenityContext.Amenities.Add(amenity);
            await _amenityContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAmenity), new { id = amenity.Id }, amenity);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }
            _amenityContext.Entry(amenity).State = EntityState.Modified;
            try
            {
                await _amenityContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAmenity(int id)
        {
            if (_amenityContext.Amenities == null)
            {
                return NotFound();
            }
            var amenity = await _amenityContext.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();

            }
            _amenityContext.Amenities.Remove(amenity);
            await _amenityContext.SaveChangesAsync();

            return Ok();
        }
    }
}


