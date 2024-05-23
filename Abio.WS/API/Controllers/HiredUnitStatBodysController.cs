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
	
	public class HiredUnitStatBodysController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatBodysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatBody>>> GetHiredUnitStatBody()
        {
          if (_context.HiredUnitStatBody == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatBody.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatBody>> GetHiredUnitStatBody(Guid id)
		{
          if (_context.HiredUnitStatBody == null)
          {
              return NotFound();
          }
            var hiredunitstatbody = await _context.HiredUnitStatBody.FindAsync(id);

            if (hiredunitstatbody  == null)
            {
                return NotFound();
            }

            return hiredunitstatbody;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatBody(Guid id, HiredUnitStatBody hiredunitstatbody)
        {
            if (id != hiredunitstatbody.HiredUnitStatBodyId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatbody).State = EntityState.Modified;

            try
            {
                  hiredunitstatbody.HiredUnitStatBodyId = Guid.NewGuid();
                  if (this.HiredUnitStatBodyExists(hiredunitstatbody.HiredUnitStatBodyId))
                  {
                    hiredunitstatbody.HiredUnitStatBodyId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatBodyExists(id))
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
        public async Task<ActionResult<HiredUnitStatBody>> PostHiredUnitStatBody(HiredUnitStatBody hiredunitstatbody)
        {
          if (_context.HiredUnitStatBody == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatBody'  is null.");
          }
            _context.HiredUnitStatBody.Add(hiredunitstatbody);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatBodyExists(hiredunitstatbody.HiredUnitStatBodyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatBody", new { id = hiredunitstatbody.HiredUnitStatBodyId }, hiredunitstatbody);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatBody(Guid id)
        {
            if (_context.HiredUnitStatBody == null)
            {
                return NotFound();
            }
            var hiredunitstatbody = await _context.HiredUnitStatBody.FindAsync(id);
            if (hiredunitstatbody == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatBody.Remove(hiredunitstatbody);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatBodyExists(Guid id)
        {
            return (_context.HiredUnitStatBody?.Any(e => e.HiredUnitStatBodyId == id)).GetValueOrDefault();
        }
	}
}

