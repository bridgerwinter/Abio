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
	
	public class HiredUnitStatsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStat>>> GetHiredUnitStat()
        {
          if (_context.HiredUnitStat == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStat.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStat>> GetHiredUnitStat(Guid id)
		{
          if (_context.HiredUnitStat == null)
          {
              return NotFound();
          }
            var hiredunitstat = await _context.HiredUnitStat.FindAsync(id);

            if (hiredunitstat  == null)
            {
                return NotFound();
            }

            return hiredunitstat;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStat(Guid id, HiredUnitStat hiredunitstat)
        {
            if (id != hiredunitstat.HiredUnitStatId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatExists(id))
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
        public async Task<ActionResult<HiredUnitStat>> PostHiredUnitStat(HiredUnitStat hiredunitstat)
        {
          if (_context.HiredUnitStat == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStat'  is null.");
          }
            _context.HiredUnitStat.Add(hiredunitstat);
            try
            {
                hiredunitstat.HiredUnitStatId = Guid.NewGuid();
                if (this.HiredUnitStatExists(hiredunitstat.HiredUnitStatId))
                {
                  hiredunitstat.HiredUnitStatId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatExists(hiredunitstat.HiredUnitStatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStat", new { id = hiredunitstat.HiredUnitStatId }, hiredunitstat);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStat(Guid id)
        {
            if (_context.HiredUnitStat == null)
            {
                return NotFound();
            }
            var hiredunitstat = await _context.HiredUnitStat.FindAsync(id);
            if (hiredunitstat == null)
            {
                return NotFound();
            }

            _context.HiredUnitStat.Remove(hiredunitstat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatExists(Guid id)
        {
            return (_context.HiredUnitStat?.Any(e => e.HiredUnitStatId == id)).GetValueOrDefault();
        }
	}
}

