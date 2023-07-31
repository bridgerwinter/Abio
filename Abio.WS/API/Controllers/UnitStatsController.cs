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
    public class UnitStatsController : ControllerBase
    {
        private readonly AbioContext _context;

        public UnitStatsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UnitStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitStat>>> GetUnitStat()
        {
          if (_context.UnitStat == null)
          {
              return NotFound();
          }
            return await _context.UnitStat.ToListAsync();
        }

        // GET: api/UnitStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitStat>> GetUnitStat(Guid id)
        {
          if (_context.UnitStat == null)
          {
              return NotFound();
          }
            var unitStat = await _context.UnitStat.FindAsync(id);

            if (unitStat == null)
            {
                return NotFound();
            }

            return unitStat;
        }

        // PUT: api/UnitStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitStat(Guid id, UnitStat unitStat)
        {
            if (id != unitStat.UnitStatId)
            {
                return BadRequest();
            }

            _context.Entry(unitStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitStatExists(id))
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

        // POST: api/UnitStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitStat>> PostUnitStat(UnitStat unitStat)
        {
          if (_context.UnitStat == null)
          {
              return Problem("Entity set 'AbioContext.UnitStat'  is null.");
          }
            _context.UnitStat.Add(unitStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitStatExists(unitStat.UnitStatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitStat", new { id = unitStat.UnitStatId }, unitStat);
        }

        // DELETE: api/UnitStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitStat(Guid id)
        {
            if (_context.UnitStat == null)
            {
                return NotFound();
            }
            var unitStat = await _context.UnitStat.FindAsync(id);
            if (unitStat == null)
            {
                return NotFound();
            }

            _context.UnitStat.Remove(unitStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitStatExists(Guid id)
        {
            return (_context.UnitStat?.Any(e => e.UnitStatId == id)).GetValueOrDefault();
        }
    }
}
