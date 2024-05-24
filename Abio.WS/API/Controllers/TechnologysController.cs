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
	
	public class TechnologysController : ControllerBase
	{
		private readonly AbioContext _context;

		public TechnologysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnology()
        {
          if (_context.Technology == null)
          {
              return NotFound();
          }
            return await _context.Technology.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Technology>> GetTechnology(int id)
		{
          if (_context.Technology == null)
          {
              return NotFound();
          }
            var technology = await _context.Technology.FindAsync(id);

            if (technology  == null)
            {
                return NotFound();
            }

            return technology;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutTechnology(int id, Technology technology)
        {
            if (id != technology.TechnologyId)
            {
                return BadRequest();
            }

            _context.Entry(technology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologyExists(id))
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
        public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
        {
          if (_context.Technology == null)
          {
              return Problem("Entity set 'AbioContext.Technology'  is null.");
          }
            _context.Technology.Add(technology);
            try
            {
                  
                  
                  
                  
                                  await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TechnologyExists(technology.TechnologyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTechnology", new { id = technology.TechnologyId }, technology);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            if (_context.Technology == null)
            {
                return NotFound();
            }
            var technology = await _context.Technology.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }

            _context.Technology.Remove(technology);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnologyExists(int id)
        {
            return (_context.Technology?.Any(e => e.TechnologyId == id)).GetValueOrDefault();
        }
	}
}

