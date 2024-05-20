using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abio.Library.DatabaseModels;
using Attribute = Abio.Library.DatabaseModels.Attribute;


namespace Abio.WS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	
	public class ResourceGainsController : ControllerBase
	{
		private readonly AbioContext _context;

		public ResourceGainsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceGain>>> GetResourceGain()
        {
          if (_context.ResourceGain == null)
          {
              return NotFound();
          }
            return await _context.ResourceGain.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ResourceGain>> GetResourceGain(Guid id)
		{
          if (_context.ResourceGain == null)
          {
              return NotFound();
          }
            var resourcegain = await _context.ResourceGain.FindAsync(id);

            if (resourcegain  == null)
            {
                return NotFound();
            }

            return resourcegain;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutResourceGain(Guid id, ResourceGain resourcegain)
        {
            if (id != resourcegain.ResourceGainId)
            {
                return BadRequest();
            }

            _context.Entry(resourcegain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceGainExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ResourceGain>> PostResourceGain(ResourceGain resourcegain)
        {
          if (_context.ResourceGain == null)
          {
              return Problem("Entity set 'AbioContext.ResourceGain'  is null.");
          }
            _context.ResourceGain.Add(resourcegain);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResourceGainExists(resourcegain.ResourceGainId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResourceGain", new { id = resourcegain.ResourceGainId }, resourcegain);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceGain(Guid id)
        {
            if (_context.ResourceGain == null)
            {
                return NotFound();
            }
            var resourcegain = await _context.ResourceGain.FindAsync(id);
            if (resourcegain == null)
            {
                return NotFound();
            }

            _context.ResourceGain.Remove(resourcegain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceGainExists(Guid id)
        {
            return (_context.ResourceGain?.Any(e => e.ResourceGainId == id)).GetValueOrDefault();
        }
	}
}

