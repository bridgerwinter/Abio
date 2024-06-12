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
	
	public partial class HiredUnitStatMagicsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatMagicsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatMagic>>> GetHiredUnitStatMagic()
        {
          if (_context.HiredUnitStatMagic == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatMagic.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatMagic>> GetHiredUnitStatMagic(Guid id)
		{
          if (_context.HiredUnitStatMagic == null)
          {
              return NotFound();
          }
            var hiredunitstatmagic = await _context.HiredUnitStatMagic.FindAsync(id);

            if (hiredunitstatmagic  == null)
            {
                return NotFound();
            }

            return hiredunitstatmagic;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatMagic(Guid id, HiredUnitStatMagic hiredunitstatmagic)
        {
            if (id != hiredunitstatmagic.HiredUnitStatMagicId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatmagic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatMagicExists(id))
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
        public async Task<ActionResult<HiredUnitStatMagic>> PostHiredUnitStatMagic(HiredUnitStatMagic hiredunitstatmagic)
        {
          if (_context.HiredUnitStatMagic == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatMagic'  is null.");
          }
            _context.HiredUnitStatMagic.Add(hiredunitstatmagic);
            try
            {
                hiredunitstatmagic.HiredUnitStatMagicId = Guid.NewGuid();
                if (this.HiredUnitStatMagicExists(hiredunitstatmagic.HiredUnitStatMagicId))
                {
                  hiredunitstatmagic.HiredUnitStatMagicId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatMagicExists(hiredunitstatmagic.HiredUnitStatMagicId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatMagic", new { id = hiredunitstatmagic.HiredUnitStatMagicId }, hiredunitstatmagic);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatMagic(Guid id)
        {
            if (_context.HiredUnitStatMagic == null)
            {
                return NotFound();
            }
            var hiredunitstatmagic = await _context.HiredUnitStatMagic.FindAsync(id);
            if (hiredunitstatmagic == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatMagic.Remove(hiredunitstatmagic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatMagicExists(Guid id)
        {
            return (_context.HiredUnitStatMagic?.Any(e => e.HiredUnitStatMagicId == id)).GetValueOrDefault();
        }
	}
}

