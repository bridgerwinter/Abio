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
    public class UnitAttributesController : ControllerBase
    {
        private readonly AbioContext _context;

        public UnitAttributesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UnitAttributes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitAttribute>>> GetUnitAttribute()
        {
          if (_context.UnitAttribute == null)
          {
              return NotFound();
          }
            return await _context.UnitAttribute.ToListAsync();
        }

        // GET: api/UnitAttributes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitAttribute>> GetUnitAttribute(Guid id)
        {
          if (_context.UnitAttribute == null)
          {
              return NotFound();
          }
            var unitAttribute = await _context.UnitAttribute.FindAsync(id);

            if (unitAttribute == null)
            {
                return NotFound();
            }

            return unitAttribute;
        }

        // PUT: api/UnitAttributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitAttribute(Guid id, UnitAttribute unitAttribute)
        {
            if (id != unitAttribute.UnitAttributeId)
            {
                return BadRequest();
            }

            _context.Entry(unitAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitAttributeExists(id))
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

        // POST: api/UnitAttributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitAttribute>> PostUnitAttribute(UnitAttribute unitAttribute)
        {
          if (_context.UnitAttribute == null)
          {
              return Problem("Entity set 'AbioContext.UnitAttribute'  is null.");
          }

          //Make these trigger only if we get a conflict error. Might save a minor amount of time in the long run. For all Create Commands. 
            unitAttribute.UnitAttributeId = Guid.NewGuid();
            bool guidExists = await _context.Unit.AnyAsync(p => p.UnitId == unitAttribute.UnitAttributeId);
            while (guidExists)
            {
                if (guidExists)
                {
                    unitAttribute.UnitAttributeId = Guid.NewGuid();
                }
                guidExists = await _context.UnitAttribute.AnyAsync(p => p.UnitAttributeId == unitAttribute.UnitAttributeId);
            }

            _context.UnitAttribute.Add(unitAttribute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitAttributeExists(unitAttribute.UnitAttributeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitAttribute", new { id = unitAttribute.UnitAttributeId }, unitAttribute);
        }

        // DELETE: api/UnitAttributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitAttribute(Guid id)
        {
            if (_context.UnitAttribute == null)
            {
                return NotFound();
            }
            var unitAttribute = await _context.UnitAttribute.FindAsync(id);
            if (unitAttribute == null)
            {
                return NotFound();
            }

            _context.UnitAttribute.Remove(unitAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitAttributeExists(Guid id)
        {
            return (_context.UnitAttribute?.Any(e => e.UnitAttributeId == id)).GetValueOrDefault();
        }
    }
}
