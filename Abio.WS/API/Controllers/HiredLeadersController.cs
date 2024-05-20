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
	
	public class HiredLeadersController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredLeadersController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredLeader>>> GetHiredLeader()
        {
          if (_context.HiredLeader == null)
          {
              return NotFound();
          }
            return await _context.HiredLeader.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredLeader>> GetHiredLeader(Guid id)
		{
          if (_context.HiredLeader == null)
          {
              return NotFound();
          }
            var hiredleader = await _context.HiredLeader.FindAsync(id);

            if (hiredleader  == null)
            {
                return NotFound();
            }

            return hiredleader;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredLeader(Guid id, HiredLeader hiredleader)
        {
            if (id != hiredleader.HiredLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(hiredleader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredLeaderExists(id))
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
        public async Task<ActionResult<HiredLeader>> PostHiredLeader(HiredLeader hiredleader)
        {
          if (_context.HiredLeader == null)
          {
              return Problem("Entity set 'AbioContext.HiredLeader'  is null.");
          }
            _context.HiredLeader.Add(hiredleader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredLeaderExists(hiredleader.HiredLeaderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredLeader", new { id = hiredleader.HiredLeaderId }, hiredleader);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredLeader(Guid id)
        {
            if (_context.HiredLeader == null)
            {
                return NotFound();
            }
            var hiredleader = await _context.HiredLeader.FindAsync(id);
            if (hiredleader == null)
            {
                return NotFound();
            }

            _context.HiredLeader.Remove(hiredleader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredLeaderExists(Guid id)
        {
            return (_context.HiredLeader?.Any(e => e.HiredLeaderId == id)).GetValueOrDefault();
        }
	}
}

