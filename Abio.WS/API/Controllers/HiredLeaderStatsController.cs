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
        public async Task<ActionResult<IEnumerable<HiredLeaderStat>>> GetHiredLeaderStat()
        {
          if (_context.HiredLeaderStat == null)
          {
              return NotFound();
          }
            return await _context.HiredLeaderStat.ToListAsync();
        }

        // GET: api/HiredLeaderStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredLeaderStat>> GetHiredLeaderStat(Guid id)
        {
          if (_context.HiredLeaderStat == null)
          {
              return NotFound();
          }
            var hiredLeaderStat = await _context.HiredLeaderStat.FindAsync(id);

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
            if (id != hiredLeaderStat.HiredLeaderStatId)
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
          if (_context.HiredLeaderStat == null)
          {
              return Problem("Entity set 'AbioContext.HiredLeaderStat'  is null.");
          }
            _context.HiredLeaderStat.Add(hiredLeaderStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredLeaderStatExists(hiredLeaderStat.HiredLeaderStatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredLeaderStat", new { id = hiredLeaderStat.HiredLeaderStatId }, hiredLeaderStat);
        }

        // DELETE: api/HiredLeaderStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredLeaderStat(Guid id)
        {
            if (_context.HiredLeaderStat == null)
            {
                return NotFound();
            }
            var hiredLeaderStat = await _context.HiredLeaderStat.FindAsync(id);
            if (hiredLeaderStat == null)
            {
                return NotFound();
            }

            _context.HiredLeaderStat.Remove(hiredLeaderStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredLeaderStatExists(Guid id)
        {
            return (_context.HiredLeaderStat?.Any(e => e.HiredLeaderStatId == id)).GetValueOrDefault();
        }
    }
}
