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
	
	public class HiredUnitStatCivilsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatCivilsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatCivil>>> GetHiredUnitStatCivil()
        {
          if (_context.HiredUnitStatCivil == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatCivil.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatCivil>> GetHiredUnitStatCivil(Guid id)
		{
          if (_context.HiredUnitStatCivil == null)
          {
              return NotFound();
          }
            var hiredunitstatcivil = await _context.HiredUnitStatCivil.FindAsync(id);

            if (hiredunitstatcivil  == null)
            {
                return NotFound();
            }

            return hiredunitstatcivil;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatCivil(Guid id, HiredUnitStatCivil hiredunitstatcivil)
        {
            if (id != hiredunitstatcivil.HiredUnitStatCivilId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatcivil).State = EntityState.Modified;

            try
            {
                  hiredunitstatcivil.HiredUnitStatCivilId = Guid.NewGuid();
                  if (this.HiredUnitStatCivilExists(hiredunitstatcivil.HiredUnitStatCivilId))
                  {
                    hiredunitstatcivil.HiredUnitStatCivilId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatCivilExists(id))
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
        public async Task<ActionResult<HiredUnitStatCivil>> PostHiredUnitStatCivil(HiredUnitStatCivil hiredunitstatcivil)
        {
          if (_context.HiredUnitStatCivil == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatCivil'  is null.");
          }
            _context.HiredUnitStatCivil.Add(hiredunitstatcivil);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatCivilExists(hiredunitstatcivil.HiredUnitStatCivilId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatCivil", new { id = hiredunitstatcivil.HiredUnitStatCivilId }, hiredunitstatcivil);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatCivil(Guid id)
        {
            if (_context.HiredUnitStatCivil == null)
            {
                return NotFound();
            }
            var hiredunitstatcivil = await _context.HiredUnitStatCivil.FindAsync(id);
            if (hiredunitstatcivil == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatCivil.Remove(hiredunitstatcivil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatCivilExists(Guid id)
        {
            return (_context.HiredUnitStatCivil?.Any(e => e.HiredUnitStatCivilId == id)).GetValueOrDefault();
        }
	}
}

