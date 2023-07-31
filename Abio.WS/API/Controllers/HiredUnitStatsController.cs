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
    public class HiredUnitStatsController : ControllerBase
    {
        private readonly AbioContext _context;

        public HiredUnitStatsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/HiredUnitStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStat>>> GetHiredUnitStat()
        {
          if (_context.HiredUnitStat == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStat.ToListAsync();
        }

        // GET: api/HiredUnitStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredUnitStat>> GetHiredUnitStat(Guid id)
        {
          if (_context.HiredUnitStat == null)
          {
              return NotFound();
          }
            var hiredUnitStat = await _context.HiredUnitStat.FindAsync(id);

            if (hiredUnitStat == null)
            {
                return NotFound();
            }

            return hiredUnitStat;
        }

        // PUT: api/HiredUnitStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStat(Guid id, HiredUnitStat hiredUnitStat)
        {
            if (id != hiredUnitStat.HiredUnitStatId)
            {
                return BadRequest();
            }

            _context.Entry(hiredUnitStat).State = EntityState.Modified;

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

        // POST: api/HiredUnitStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredUnitStat>> PostHiredUnitStat(HiredUnitStat hiredUnitStat)
        {
          if (_context.HiredUnitStat == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStat'  is null.");
          }
            _context.HiredUnitStat.Add(hiredUnitStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatExists(hiredUnitStat.HiredUnitStatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStat", new { id = hiredUnitStat.HiredUnitStatId }, hiredUnitStat);
        }

        // DELETE: api/HiredUnitStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStat(Guid id)
        {
            if (_context.HiredUnitStat == null)
            {
                return NotFound();
            }
            var hiredUnitStat = await _context.HiredUnitStat.FindAsync(id);
            if (hiredUnitStat == null)
            {
                return NotFound();
            }

            _context.HiredUnitStat.Remove(hiredUnitStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatExists(Guid id)
        {
            return (_context.HiredUnitStat?.Any(e => e.HiredUnitStatId == id)).GetValueOrDefault();
        }
    }
}
