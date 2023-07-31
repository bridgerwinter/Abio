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
    public class UserCitiesLeadersController : ControllerBase
    {
        private readonly AbioContext _context;

        public UserCitiesLeadersController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UserCitiesLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCitiesLeader>>> GetUserCitiesLeaders()
        {
          if (_context.UserCitiesLeaders == null)
          {
              return NotFound();
          }
            return await _context.UserCitiesLeaders.ToListAsync();
        }

        // GET: api/UserCitiesLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCitiesLeader>> GetUserCitiesLeader(Guid id)
        {
          if (_context.UserCitiesLeaders == null)
          {
              return NotFound();
          }
            var userCitiesLeader = await _context.UserCitiesLeaders.FindAsync(id);

            if (userCitiesLeader == null)
            {
                return NotFound();
            }

            return userCitiesLeader;
        }

        // PUT: api/UserCitiesLeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCitiesLeader(Guid id, UserCitiesLeader userCitiesLeader)
        {
            if (id != userCitiesLeader.UserCityLeadersId)
            {
                return BadRequest();
            }

            _context.Entry(userCitiesLeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCitiesLeaderExists(id))
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

        // POST: api/UserCitiesLeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCitiesLeader>> PostUserCitiesLeader(UserCitiesLeader userCitiesLeader)
        {
          if (_context.UserCitiesLeaders == null)
          {
              return Problem("Entity set 'AbioContext.UserCitiesLeaders'  is null.");
          }
            _context.UserCitiesLeaders.Add(userCitiesLeader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCitiesLeaderExists(userCitiesLeader.UserCityLeadersId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCitiesLeader", new { id = userCitiesLeader.UserCityLeadersId }, userCitiesLeader);
        }

        // DELETE: api/UserCitiesLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCitiesLeader(Guid id)
        {
            if (_context.UserCitiesLeaders == null)
            {
                return NotFound();
            }
            var userCitiesLeader = await _context.UserCitiesLeaders.FindAsync(id);
            if (userCitiesLeader == null)
            {
                return NotFound();
            }

            _context.UserCitiesLeaders.Remove(userCitiesLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCitiesLeaderExists(Guid id)
        {
            return (_context.UserCitiesLeaders?.Any(e => e.UserCityLeadersId == id)).GetValueOrDefault();
        }
    }
}
