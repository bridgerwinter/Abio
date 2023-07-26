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
    public class UnitGroupsController : ControllerBase
    {
        private readonly AbioContext _context;

        public UnitGroupsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UnitGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitGroup>>> GetUnitGroups()
        {
          if (_context.UnitGroups == null)
          {
              return NotFound();
          }
            return await _context.UnitGroups.ToListAsync();
        }

        // GET: api/UnitGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitGroup>> GetUnitGroup(Guid id)
        {
          if (_context.UnitGroups == null)
          {
              return NotFound();
          }
            var unitGroup = await _context.UnitGroups.FindAsync(id);

            if (unitGroup == null)
            {
                return NotFound();
            }

            return unitGroup;
        }

        // PUT: api/UnitGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitGroup(Guid id, UnitGroup unitGroup)
        {
            if (id != unitGroup.UnitGroupsId)
            {
                return BadRequest();
            }

            _context.Entry(unitGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitGroupExists(id))
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

        // POST: api/UnitGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitGroup>> PostUnitGroup(UnitGroup unitGroup)
        {
          if (_context.UnitGroups == null)
          {
              return Problem("Entity set 'AbioContext.UnitGroups'  is null.");
          }
            _context.UnitGroups.Add(unitGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitGroupExists(unitGroup.UnitGroupsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitGroup", new { id = unitGroup.UnitGroupsId }, unitGroup);
        }

        // DELETE: api/UnitGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitGroup(Guid id)
        {
            if (_context.UnitGroups == null)
            {
                return NotFound();
            }
            var unitGroup = await _context.UnitGroups.FindAsync(id);
            if (unitGroup == null)
            {
                return NotFound();
            }

            _context.UnitGroups.Remove(unitGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitGroupExists(Guid id)
        {
            return (_context.UnitGroups?.Any(e => e.UnitGroupsId == id)).GetValueOrDefault();
        }
    }
}
