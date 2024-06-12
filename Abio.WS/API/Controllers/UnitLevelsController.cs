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
	
	public partial class UnitLevelsController : ControllerBase
	{
		private readonly AbioContext _context;

		public UnitLevelsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitLevel>>> GetUnitLevel()
        {
          if (_context.UnitLevel == null)
          {
              return NotFound();
          }
            return await _context.UnitLevel.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<UnitLevel>> GetUnitLevel(int id)
		{
          if (_context.UnitLevel == null)
          {
              return NotFound();
          }
            var unitlevel = await _context.UnitLevel.FindAsync(id);

            if (unitlevel  == null)
            {
                return NotFound();
            }

            return unitlevel;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutUnitLevel(int id, UnitLevel unitlevel)
        {
            if (id != unitlevel.UnitLevelId)
            {
                return BadRequest();
            }

            _context.Entry(unitlevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitLevelExists(id))
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
        public async Task<ActionResult<UnitLevel>> PostUnitLevel(UnitLevel unitlevel)
        {
          if (_context.UnitLevel == null)
          {
              return Problem("Entity set 'AbioContext.UnitLevel'  is null.");
          }
            _context.UnitLevel.Add(unitlevel);
            try
            {
                
                
                
                
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitLevelExists(unitlevel.UnitLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitLevel", new { id = unitlevel.UnitLevelId }, unitlevel);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitLevel(int id)
        {
            if (_context.UnitLevel == null)
            {
                return NotFound();
            }
            var unitlevel = await _context.UnitLevel.FindAsync(id);
            if (unitlevel == null)
            {
                return NotFound();
            }

            _context.UnitLevel.Remove(unitlevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitLevelExists(int id)
        {
            return (_context.UnitLevel?.Any(e => e.UnitLevelId == id)).GetValueOrDefault();
        }
	}
}

