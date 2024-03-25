using ApiVilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationDbContext _villaContext;
        public VillaController(ApplicationDbContext villaContext)
        {
            _villaContext = villaContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villa>>> GetVillas()
        {
            if (_villaContext.Villas == null)
            {
                return NotFound();
            }
            return await _villaContext.Villas.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Villa>> GetVilla(int id)
        {
            if (_villaContext.Villas == null)
            {
                return NotFound();
            }

            var villa = await _villaContext.Villas.FindAsync(id);
            if(villa == null)
            {
                return NotFound();
            }
            return villa; 


        }

        [HttpPost]
        public async Task<ActionResult<Villa>> PostVilla(Villa villa)
        {
            _villaContext.Villas.Add(villa);
            await _villaContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVilla), new { id = villa.Id }, villa);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutVilla(int id, Villa villa)
        {
            if(id != villa.Id)
            {
                return BadRequest();
            }
            _villaContext.Entry(villa).State = EntityState.Modified;
            try
            {
                await _villaContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException) 
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVilla(int id)
        {
            if(_villaContext.Villas == null)
            {
                return NotFound();
            }
            var villa = await _villaContext.Villas.FindAsync(id);
            if(villa == null) 
            {
                return  NotFound(); 

            }
            _villaContext.Villas.Remove(villa);
            await _villaContext.SaveChangesAsync();

            return Ok();
        }
    }

    
}
