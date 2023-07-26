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
    public class HiredUnitsController : ControllerBase
    {
        private readonly AbioContext _context;

        public HiredUnitsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/HiredUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnit>>> GetHiredUnits()
        {
          if (_context.HiredUnits == null)
          {
              return NotFound();
          }
            return await _context.HiredUnits.ToListAsync();
        }

        // GET: api/HiredUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredUnit>> GetHiredUnit(Guid id)
        {
          if (_context.HiredUnits == null)
          {
              return NotFound();
          }
            var hiredUnit = await _context.HiredUnits.FindAsync(id);

            if (hiredUnit == null)
            {
                return NotFound();
            }

            return hiredUnit;
        }

        // PUT: api/HiredUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnit(Guid id, HiredUnit hiredUnit)
        {
            if (id != hiredUnit.HiredUnitId)
            {
                return BadRequest();
            }

            _context.Entry(hiredUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitExists(id))
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

        // POST: api/HiredUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredUnit>> PostHiredUnit(HiredUnit hiredUnit)
        {
          if (_context.HiredUnits == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnits'  is null.");
          }
            _context.HiredUnits.Add(hiredUnit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitExists(hiredUnit.HiredUnitId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnit", new { id = hiredUnit.HiredUnitId }, hiredUnit);
        }

        // DELETE: api/HiredUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnit(Guid id)
        {
            if (_context.HiredUnits == null)
            {
                return NotFound();
            }
            var hiredUnit = await _context.HiredUnits.FindAsync(id);
            if (hiredUnit == null)
            {
                return NotFound();
            }

            _context.HiredUnits.Remove(hiredUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitExists(Guid id)
        {
            return (_context.HiredUnits?.Any(e => e.HiredUnitId == id)).GetValueOrDefault();
        }
    }
}
