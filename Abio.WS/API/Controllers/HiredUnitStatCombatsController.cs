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
	
	public class HiredUnitStatCombatsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatCombatsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatCombat>>> GetHiredUnitStatCombat()
        {
          if (_context.HiredUnitStatCombat == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatCombat.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatCombat>> GetHiredUnitStatCombat(Guid id)
		{
          if (_context.HiredUnitStatCombat == null)
          {
              return NotFound();
          }
            var hiredunitstatcombat = await _context.HiredUnitStatCombat.FindAsync(id);

            if (hiredunitstatcombat  == null)
            {
                return NotFound();
            }

            return hiredunitstatcombat;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatCombat(Guid id, HiredUnitStatCombat hiredunitstatcombat)
        {
            if (id != hiredunitstatcombat.HiredUnitStatCombatId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatcombat).State = EntityState.Modified;

            try
            {
                  hiredunitstatcombat.HiredUnitStatCombatId = Guid.NewGuid();
                  if (this.HiredUnitStatCombatExists(hiredunitstatcombat.HiredUnitStatCombatId))
                  {
                    hiredunitstatcombat.HiredUnitStatCombatId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatCombatExists(id))
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
        public async Task<ActionResult<HiredUnitStatCombat>> PostHiredUnitStatCombat(HiredUnitStatCombat hiredunitstatcombat)
        {
          if (_context.HiredUnitStatCombat == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatCombat'  is null.");
          }
            _context.HiredUnitStatCombat.Add(hiredunitstatcombat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatCombatExists(hiredunitstatcombat.HiredUnitStatCombatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatCombat", new { id = hiredunitstatcombat.HiredUnitStatCombatId }, hiredunitstatcombat);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatCombat(Guid id)
        {
            if (_context.HiredUnitStatCombat == null)
            {
                return NotFound();
            }
            var hiredunitstatcombat = await _context.HiredUnitStatCombat.FindAsync(id);
            if (hiredunitstatcombat == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatCombat.Remove(hiredunitstatcombat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatCombatExists(Guid id)
        {
            return (_context.HiredUnitStatCombat?.Any(e => e.HiredUnitStatCombatId == id)).GetValueOrDefault();
        }
	}
}

