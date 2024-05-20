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
	
	public class BodyPartsController : ControllerBase
	{
		private readonly AbioContext _context;

		public BodyPartsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyPart>>> GetBodyPart()
        {
          if (_context.BodyPart == null)
          {
              return NotFound();
          }
            return await _context.BodyPart.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<BodyPart>> GetBodyPart(int id)
		{
          if (_context.BodyPart == null)
          {
              return NotFound();
          }
            var bodypart = await _context.BodyPart.FindAsync(id);

            if (bodypart  == null)
            {
                return NotFound();
            }

            return bodypart;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutBodyPart(int id, BodyPart bodypart)
        {
            if (id != bodypart.BodyPartId)
            {
                return BadRequest();
            }

            _context.Entry(bodypart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyPartExists(id))
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
        public async Task<ActionResult<BodyPart>> PostBodyPart(BodyPart bodypart)
        {
          if (_context.BodyPart == null)
          {
              return Problem("Entity set 'AbioContext.BodyPart'  is null.");
          }
            _context.BodyPart.Add(bodypart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BodyPartExists(bodypart.BodyPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBodyPart", new { id = bodypart.BodyPartId }, bodypart);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyPart(int id)
        {
            if (_context.BodyPart == null)
            {
                return NotFound();
            }
            var bodypart = await _context.BodyPart.FindAsync(id);
            if (bodypart == null)
            {
                return NotFound();
            }

            _context.BodyPart.Remove(bodypart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodyPartExists(int id)
        {
            return (_context.BodyPart?.Any(e => e.BodyPartId == id)).GetValueOrDefault();
        }
	}
}

