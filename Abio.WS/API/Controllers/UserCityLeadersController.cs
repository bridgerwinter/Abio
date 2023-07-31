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
    public class UserCityLeadersController : ControllerBase
    {
        private readonly AbioContext _context;

        public UserCityLeadersController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UserCityLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCityLeader>>> GetUserCityLeader()
        {
          if (_context.UserCityLeader == null)
          {
              return NotFound();
          }
            return await _context.UserCityLeader.ToListAsync();
        }

        // GET: api/UserCityLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCityLeader>> GetUserCityLeader(Guid id)
        {
          if (_context.UserCityLeader == null)
          {
              return NotFound();
          }
            var userCityLeader = await _context.UserCityLeader.FindAsync(id);

            if (userCityLeader == null)
            {
                return NotFound();
            }

            return userCityLeader;
        }

        // PUT: api/UserCityLeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCityLeader(Guid id, UserCityLeader userCityLeader)
        {
            if (id != userCityLeader.UserCityLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(userCityLeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCityLeaderExists(id))
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

        // POST: api/UserCityLeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCityLeader>> PostUserCityLeader(UserCityLeader userCityLeader)
        {
          if (_context.UserCityLeader == null)
          {
              return Problem("Entity set 'AbioContext.UserCityLeader'  is null.");
          }
            _context.UserCityLeader.Add(userCityLeader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCityLeaderExists(userCityLeader.UserCityLeaderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCityLeader", new { id = userCityLeader.UserCityLeaderId }, userCityLeader);
        }

        // DELETE: api/UserCityLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCityLeader(Guid id)
        {
            if (_context.UserCityLeader == null)
            {
                return NotFound();
            }
            var userCityLeader = await _context.UserCityLeader.FindAsync(id);
            if (userCityLeader == null)
            {
                return NotFound();
            }

            _context.UserCityLeader.Remove(userCityLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCityLeaderExists(Guid id)
        {
            return (_context.UserCityLeader?.Any(e => e.UserCityLeaderId == id)).GetValueOrDefault();
        }
    }
}
