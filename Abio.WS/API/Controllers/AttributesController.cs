using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abio.Library.DatabaseModels;
using Attribute = Abio.Library.DatabaseModels.Attribute;


namespace Abio.WS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	
	public class AttributesController : ControllerBase
	{
		private readonly AbioContext _context;

		public AttributesController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attribute>>> GetAttribute()
        {
          if (_context.Attribute == null)
          {
              return NotFound();
          }
            return await _context.Attribute.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Attribute>> GetAttribute(int id)
		{
          if (_context.Attribute == null)
          {
              return NotFound();
          }
            var attribute = await _context.Attribute.FindAsync(id);

            if (attribute  == null)
            {
                return NotFound();
            }

            return attribute;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute(int id, Attribute attribute)
        {
            if (id != attribute.AttributeId)
            {
                return BadRequest();
            }

            _context.Entry(attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Attribute>> PostAttribute(Attribute attribute)
        {
          if (_context.Attribute == null)
          {
              return Problem("Entity set 'AbioContext.Attribute'  is null.");
          }
            _context.Attribute.Add(attribute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttributeExists(attribute.AttributeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttribute", new { id = attribute.AttributeId }, attribute);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            if (_context.Attribute == null)
            {
                return NotFound();
            }
            var attribute = await _context.Attribute.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            _context.Attribute.Remove(attribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeExists(int id)
        {
            return (_context.Attribute?.Any(e => e.AttributeId == id)).GetValueOrDefault();
        }
	}
}

