using ApiVilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly ApplicationDbContext _villanumberContext;
        public VillaNumberController(ApplicationDbContext villanumberContext)
        {
            _villanumberContext = villanumberContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaNumber>>> GetVillaNumbers()
        {
            if (_villanumberContext.VillaNumbers == null)
            {
                return NotFound();
            }
            return await _villanumberContext.VillaNumbers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VillaNumber>> GetVillaNumber(int id)
        {
            if (_villanumberContext.VillaNumbers == null)
            {
                return NotFound();
            }

            var villanumber = await _villanumberContext.VillaNumbers.FindAsync(id);
            if (villanumber == null)
            {
                return NotFound();
            }
            return villanumber;


        }

        [HttpPost]
        public async Task<ActionResult<VillaNumber>> PostVilla(VillaNumber villanumber)
        {
            _villanumberContext.VillaNumbers.Add(villanumber);
            await _villanumberContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVillaNumber), new { id = villanumber.Id }, villanumber);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutVillaNumber(int id, VillaNumber villanumber)
        {
            if (id != villanumber.Id)
            {
                return BadRequest();
            }
            _villanumberContext.Entry(villanumber).State = EntityState.Modified;
            try
            {
                await _villanumberContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVillaNumber(int id)
        {
            if (_villanumberContext.VillaNumbers == null)
            {
                return NotFound();
            }
            var villanumber = await _villanumberContext.VillaNumbers.FindAsync(id);
            if (villanumber == null)
            {
                return NotFound();

            }
            _villanumberContext.VillaNumbers.Remove(villanumber);
            await _villanumberContext.SaveChangesAsync();

            return Ok();
        }
    }
}
