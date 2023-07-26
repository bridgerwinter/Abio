using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abio.WS.API.DatabaseModels;

namespace Abio.WS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiredUnitsStatsController : ControllerBase
    {
        private readonly AbioContext _context;

        public HiredUnitsStatsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/HiredUnitsStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitsStat>>> GetHiredUnitsStats()
        {
          if (_context.HiredUnitsStats == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitsStats.ToListAsync();
        }

        // GET: api/HiredUnitsStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredUnitsStat>> GetHiredUnitsStat(Guid id)
        {
          if (_context.HiredUnitsStats == null)
          {
              return NotFound();
          }
            var hiredUnitsStat = await _context.HiredUnitsStats.FindAsync(id);

            if (hiredUnitsStat == null)
            {
                return NotFound();
            }

            return hiredUnitsStat;
        }

        // PUT: api/HiredUnitsStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitsStat(Guid id, HiredUnitsStat hiredUnitsStat)
        {
            if (id != hiredUnitsStat.HiredUnitStatsId)
            {
                return BadRequest();
            }

            _context.Entry(hiredUnitsStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitsStatExists(id))
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

        // POST: api/HiredUnitsStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredUnitsStat>> PostHiredUnitsStat(HiredUnitsStat hiredUnitsStat)
        {
          if (_context.HiredUnitsStats == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitsStats'  is null.");
          }
            _context.HiredUnitsStats.Add(hiredUnitsStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitsStatExists(hiredUnitsStat.HiredUnitStatsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitsStat", new { id = hiredUnitsStat.HiredUnitStatsId }, hiredUnitsStat);
        }

        // DELETE: api/HiredUnitsStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitsStat(Guid id)
        {
            if (_context.HiredUnitsStats == null)
            {
                return NotFound();
            }
            var hiredUnitsStat = await _context.HiredUnitsStats.FindAsync(id);
            if (hiredUnitsStat == null)
            {
                return NotFound();
            }

            _context.HiredUnitsStats.Remove(hiredUnitsStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitsStatExists(Guid id)
        {
            return (_context.HiredUnitsStats?.Any(e => e.HiredUnitStatsId == id)).GetValueOrDefault();
        }
    }
}
