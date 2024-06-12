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
	
	public partial class HiredUnitsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnit>>> GetHiredUnit()
        {
          if (_context.HiredUnit == null)
          {
              return NotFound();
          }
            return await _context.HiredUnit.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnit>> GetHiredUnit(Guid id)
		{
          if (_context.HiredUnit == null)
          {
              return NotFound();
          }
            var hiredunit = await _context.HiredUnit.FindAsync(id);

            if (hiredunit  == null)
            {
                return NotFound();
            }

            return hiredunit;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnit(Guid id, HiredUnit hiredunit)
        {
            if (id != hiredunit.HiredUnitId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunit).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<HiredUnit>> PostHiredUnit(HiredUnit hiredunit)
        {
          if (_context.HiredUnit == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnit'  is null.");
          }
            _context.HiredUnit.Add(hiredunit);
            try
            {
                hiredunit.HiredUnitId = Guid.NewGuid();
                if (this.HiredUnitExists(hiredunit.HiredUnitId))
                {
                  hiredunit.HiredUnitId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitExists(hiredunit.HiredUnitId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnit", new { id = hiredunit.HiredUnitId }, hiredunit);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnit(Guid id)
        {
            if (_context.HiredUnit == null)
            {
                return NotFound();
            }
            var hiredunit = await _context.HiredUnit.FindAsync(id);
            if (hiredunit == null)
            {
                return NotFound();
            }

            _context.HiredUnit.Remove(hiredunit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitExists(Guid id)
        {
            return (_context.HiredUnit?.Any(e => e.HiredUnitId == id)).GetValueOrDefault();
        }
	}
}

