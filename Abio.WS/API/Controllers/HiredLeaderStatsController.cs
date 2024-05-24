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
	
	public class HiredLeaderStatsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredLeaderStatsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredLeaderStat>>> GetHiredLeaderStat()
        {
          if (_context.HiredLeaderStat == null)
          {
              return NotFound();
          }
            return await _context.HiredLeaderStat.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredLeaderStat>> GetHiredLeaderStat(Guid id)
		{
          if (_context.HiredLeaderStat == null)
          {
              return NotFound();
          }
            var hiredleaderstat = await _context.HiredLeaderStat.FindAsync(id);

            if (hiredleaderstat  == null)
            {
                return NotFound();
            }

            return hiredleaderstat;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredLeaderStat(Guid id, HiredLeaderStat hiredleaderstat)
        {
            if (id != hiredleaderstat.HiredLeaderStatId)
            {
                return BadRequest();
            }

            _context.Entry(hiredleaderstat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredLeaderStatExists(id))
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
        public async Task<ActionResult<HiredLeaderStat>> PostHiredLeaderStat(HiredLeaderStat hiredleaderstat)
        {
          if (_context.HiredLeaderStat == null)
          {
              return Problem("Entity set 'AbioContext.HiredLeaderStat'  is null.");
          }
            _context.HiredLeaderStat.Add(hiredleaderstat);
            try
            {
                  hiredleaderstat.HiredLeaderStatId = Guid.NewGuid();
                  if (this.HiredLeaderStatExists(hiredleaderstat.HiredLeaderStatId))
                  {
                    hiredleaderstat.HiredLeaderStatId = Guid.NewGuid();
                  }                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredLeaderStatExists(hiredleaderstat.HiredLeaderStatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredLeaderStat", new { id = hiredleaderstat.HiredLeaderStatId }, hiredleaderstat);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredLeaderStat(Guid id)
        {
            if (_context.HiredLeaderStat == null)
            {
                return NotFound();
            }
            var hiredleaderstat = await _context.HiredLeaderStat.FindAsync(id);
            if (hiredleaderstat == null)
            {
                return NotFound();
            }

            _context.HiredLeaderStat.Remove(hiredleaderstat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredLeaderStatExists(Guid id)
        {
            return (_context.HiredLeaderStat?.Any(e => e.HiredLeaderStatId == id)).GetValueOrDefault();
        }
	}
}

