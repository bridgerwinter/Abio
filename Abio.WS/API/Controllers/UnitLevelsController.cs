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
    public class UnitLevelsController : ControllerBase
    {
        private readonly AbioContext _context;

        public UnitLevelsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UnitLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitLevel>>> GetUnitLevel()
        {
          if (_context.UnitLevel == null)
          {
              return NotFound();
          }
            return await _context.UnitLevel.ToListAsync();
        }

        // GET: api/UnitLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitLevel>> GetUnitLevel(int id)
        {
          if (_context.UnitLevel == null)
          {
              return NotFound();
          }
            var unitLevel = await _context.UnitLevel.FindAsync(id);

            if (unitLevel == null)
            {
                return NotFound();
            }

            return unitLevel;
        }

        // PUT: api/UnitLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitLevel(int id, UnitLevel unitLevel)
        {
            if (id != unitLevel.UnitLevelId)
            {
                return BadRequest();
            }

            _context.Entry(unitLevel).State = EntityState.Modified;

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

        // POST: api/UnitLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitLevel>> PostUnitLevel(UnitLevel unitLevel)
        {
          if (_context.UnitLevel == null)
          {
              return Problem("Entity set 'AbioContext.UnitLevel'  is null.");
          }
            _context.UnitLevel.Add(unitLevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitLevelExists(unitLevel.UnitLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitLevel", new { id = unitLevel.UnitLevelId }, unitLevel);
        }

        // DELETE: api/UnitLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitLevel(int id)
        {
            if (_context.UnitLevel == null)
            {
                return NotFound();
            }
            var unitLevel = await _context.UnitLevel.FindAsync(id);
            if (unitLevel == null)
            {
                return NotFound();
            }

            _context.UnitLevel.Remove(unitLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitLevelExists(int id)
        {
            return (_context.UnitLevel?.Any(e => e.UnitLevelId == id)).GetValueOrDefault();
        }
    }
}
