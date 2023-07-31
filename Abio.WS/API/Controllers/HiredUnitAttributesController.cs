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
    public class HiredUnitAttributesController : ControllerBase
    {
        private readonly AbioContext _context;

        public HiredUnitAttributesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/HiredUnitAttributes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitAttribute>>> GetHiredUnitAttribute()
        {
          if (_context.HiredUnitAttribute == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitAttribute.ToListAsync();
        }

        // GET: api/HiredUnitAttributes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredUnitAttribute>> GetHiredUnitAttribute(Guid id)
        {
          if (_context.HiredUnitAttribute == null)
          {
              return NotFound();
          }
            var hiredUnitAttribute = await _context.HiredUnitAttribute.FindAsync(id);

            if (hiredUnitAttribute == null)
            {
                return NotFound();
            }

            return hiredUnitAttribute;
        }

        // PUT: api/HiredUnitAttributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitAttribute(Guid id, HiredUnitAttribute hiredUnitAttribute)
        {
            if (id != hiredUnitAttribute.HiredUnitAttributeId)
            {
                return BadRequest();
            }

            _context.Entry(hiredUnitAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitAttributeExists(id))
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

        // POST: api/HiredUnitAttributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredUnitAttribute>> PostHiredUnitAttribute(HiredUnitAttribute hiredUnitAttribute)
        {
          if (_context.HiredUnitAttribute == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitAttribute'  is null.");
          }
            _context.HiredUnitAttribute.Add(hiredUnitAttribute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitAttributeExists(hiredUnitAttribute.HiredUnitAttributeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitAttribute", new { id = hiredUnitAttribute.HiredUnitAttributeId }, hiredUnitAttribute);
        }

        // DELETE: api/HiredUnitAttributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitAttribute(Guid id)
        {
            if (_context.HiredUnitAttribute == null)
            {
                return NotFound();
            }
            var hiredUnitAttribute = await _context.HiredUnitAttribute.FindAsync(id);
            if (hiredUnitAttribute == null)
            {
                return NotFound();
            }

            _context.HiredUnitAttribute.Remove(hiredUnitAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitAttributeExists(Guid id)
        {
            return (_context.HiredUnitAttribute?.Any(e => e.HiredUnitAttributeId == id)).GetValueOrDefault();
        }
    }
}
