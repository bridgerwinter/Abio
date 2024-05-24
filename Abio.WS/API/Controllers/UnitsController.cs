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
	
	public class UnitsController : ControllerBase
	{
		private readonly AbioContext _context;

		public UnitsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnit()
        {
          if (_context.Unit == null)
          {
              return NotFound();
          }
            return await _context.Unit.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Unit>> GetUnit(int id)
		{
          if (_context.Unit == null)
          {
              return NotFound();
          }
            var unit = await _context.Unit.FindAsync(id);

            if (unit  == null)
            {
                return NotFound();
            }

            return unit;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutUnit(int id, Unit unit)
        {
            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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
        public async Task<ActionResult<Unit>> PostUnit(Unit unit)
        {
          if (_context.Unit == null)
          {
              return Problem("Entity set 'AbioContext.Unit'  is null.");
          }
            _context.Unit.Add(unit);
            try
            {
                  
                  
                  
                  
                                  await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitExists(unit.UnitId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnit", new { id = unit.UnitId }, unit);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            if (_context.Unit == null)
            {
                return NotFound();
            }
            var unit = await _context.Unit.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Unit.Remove(unit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitExists(int id)
        {
            return (_context.Unit?.Any(e => e.UnitId == id)).GetValueOrDefault();
        }
	}
}

