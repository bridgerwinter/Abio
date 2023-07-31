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
    public class HiredLeadersController : ControllerBase
    {
        private readonly AbioContext _context;

        public HiredLeadersController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/HiredLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredLeader>>> GetHiredLeader()
        {
          if (_context.HiredLeader == null)
          {
              return NotFound();
          }
            return await _context.HiredLeader.ToListAsync();
        }

        // GET: api/HiredLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HiredLeader>> GetHiredLeader(Guid id)
        {
          if (_context.HiredLeader == null)
          {
              return NotFound();
          }
            var hiredLeader = await _context.HiredLeader.FindAsync(id);

            if (hiredLeader == null)
            {
                return NotFound();
            }

            return hiredLeader;
        }

        // PUT: api/HiredLeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiredLeader(Guid id, HiredLeader hiredLeader)
        {
            if (id != hiredLeader.HiredLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(hiredLeader).State = EntityState.Modified;

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

        // POST: api/HiredLeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HiredLeader>> PostHiredLeader(HiredLeader hiredLeader)
        {
          if (_context.HiredLeader == null)
          {
              return Problem("Entity set 'AbioContext.HiredLeader'  is null.");
          }
            _context.HiredLeader.Add(hiredLeader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredLeaderExists(hiredLeader.HiredLeaderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredLeader", new { id = hiredLeader.HiredLeaderId }, hiredLeader);
        }

        // DELETE: api/HiredLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredLeader(Guid id)
        {
            if (_context.HiredLeader == null)
            {
                return NotFound();
            }
            var hiredLeader = await _context.HiredLeader.FindAsync(id);
            if (hiredLeader == null)
            {
                return NotFound();
            }

            _context.HiredLeader.Remove(hiredLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredLeaderExists(Guid id)
        {
            return (_context.HiredLeader?.Any(e => e.HiredLeaderId == id)).GetValueOrDefault();
        }
    }
}
