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
	
	public partial class HiredUnitStatFeatsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatFeatsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatFeat>>> GetHiredUnitStatFeat()
        {
          if (_context.HiredUnitStatFeat == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatFeat.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatFeat>> GetHiredUnitStatFeat(Guid id)
		{
          if (_context.HiredUnitStatFeat == null)
          {
              return NotFound();
          }
            var hiredunitstatfeat = await _context.HiredUnitStatFeat.FindAsync(id);

            if (hiredunitstatfeat  == null)
            {
                return NotFound();
            }

            return hiredunitstatfeat;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatFeat(Guid id, HiredUnitStatFeat hiredunitstatfeat)
        {
            if (id != hiredunitstatfeat.HiredUnitStatFeatId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatfeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatFeatExists(id))
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
        public async Task<ActionResult<HiredUnitStatFeat>> PostHiredUnitStatFeat(HiredUnitStatFeat hiredunitstatfeat)
        {
          if (_context.HiredUnitStatFeat == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatFeat'  is null.");
          }
            _context.HiredUnitStatFeat.Add(hiredunitstatfeat);
            try
            {
                hiredunitstatfeat.HiredUnitStatFeatId = Guid.NewGuid();
                if (this.HiredUnitStatFeatExists(hiredunitstatfeat.HiredUnitStatFeatId))
                {
                  hiredunitstatfeat.HiredUnitStatFeatId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatFeatExists(hiredunitstatfeat.HiredUnitStatFeatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatFeat", new { id = hiredunitstatfeat.HiredUnitStatFeatId }, hiredunitstatfeat);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatFeat(Guid id)
        {
            if (_context.HiredUnitStatFeat == null)
            {
                return NotFound();
            }
            var hiredunitstatfeat = await _context.HiredUnitStatFeat.FindAsync(id);
            if (hiredunitstatfeat == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatFeat.Remove(hiredunitstatfeat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatFeatExists(Guid id)
        {
            return (_context.HiredUnitStatFeat?.Any(e => e.HiredUnitStatFeatId == id)).GetValueOrDefault();
        }
	}
}

