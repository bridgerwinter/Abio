using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abio.Library.DatabaseModels;

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

        // GET: api/HiredLeaderStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredLeaderStat>>> GetHiredLeaderStats()
        {
          if (_context.HiredLeaderStats == null)
          {
              return NotFound();
          }
            return await _context.HiredLeaderStats.ToListAsync();
        }

        // GET: api/HiredLeaderStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredLeaderStat>> GetHiredLeaderStat(Guid id)
        {
          if (_context.HiredLeaderStats == null)
          {
              return NotFound();
          }
            var hiredLeaderStat = await _context.HiredLeaderStats.FindAsync(id);

            if (hiredLeaderStat == null)
            {
                return NotFound();
            }

            return hiredLeaderStat;
        }

        // PUT: api/HiredLeaderStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredLeaderStat(Guid id, HiredLeaderStat hiredLeaderStat)
        {
            if (id != hiredLeaderStat.HiredLeaderStatsId)
            {
                return BadRequest();
            }

            _context.Entry(hiredLeaderStat).State = EntityState.Modified;

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

        // POST: api/HiredLeaderStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredLeaderStat>> PostHiredLeaderStat(HiredLeaderStat hiredLeaderStat)
        {
          if (_context.HiredLeaderStats == null)
          {
              return Problem("Entity set 'AbioContext.HiredLeaderStats'  is null.");
          }
            _context.HiredLeaderStats.Add(hiredLeaderStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredLeaderStatExists(hiredLeaderStat.HiredLeaderStatsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredLeaderStat", new { id = hiredLeaderStat.HiredLeaderStatsId }, hiredLeaderStat);
        }

        // DELETE: api/HiredLeaderStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredLeaderStat(Guid id)
        {
            if (_context.HiredLeaderStats == null)
            {
                return NotFound();
            }
            var hiredLeaderStat = await _context.HiredLeaderStats.FindAsync(id);
            if (hiredLeaderStat == null)
            {
                return NotFound();
            }

            _context.HiredLeaderStats.Remove(hiredLeaderStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredLeaderStatExists(Guid id)
        {
            return (_context.HiredLeaderStats?.Any(e => e.HiredLeaderStatsId == id)).GetValueOrDefault();
        }
    }
}
