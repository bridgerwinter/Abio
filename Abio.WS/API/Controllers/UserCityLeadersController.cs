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
	
	public partial class UserCityLeadersController : ControllerBase
	{
		private readonly AbioContext _context;

		public UserCityLeadersController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCityLeader>>> GetUserCityLeader()
        {
          if (_context.UserCityLeader == null)
          {
              return NotFound();
          }
            return await _context.UserCityLeader.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<UserCityLeader>> GetUserCityLeader(Guid id)
		{
          if (_context.UserCityLeader == null)
          {
              return NotFound();
          }
            var usercityleader = await _context.UserCityLeader.FindAsync(id);

            if (usercityleader  == null)
            {
                return NotFound();
            }

            return usercityleader;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutUserCityLeader(Guid id, UserCityLeader usercityleader)
        {
            if (id != usercityleader.UserCityLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(usercityleader).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<UserCityLeader>> PostUserCityLeader(UserCityLeader usercityleader)
        {
          if (_context.UserCityLeader == null)
          {
              return Problem("Entity set 'AbioContext.UserCityLeader'  is null.");
          }
            _context.UserCityLeader.Add(usercityleader);
            try
            {
                usercityleader.UserCityLeaderId = Guid.NewGuid();
                if (this.UserCityLeaderExists(usercityleader.UserCityLeaderId))
                {
                  usercityleader.UserCityLeaderId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCityLeaderExists(usercityleader.UserCityLeaderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCityLeader", new { id = usercityleader.UserCityLeaderId }, usercityleader);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCityLeader(Guid id)
        {
            if (_context.UserCityLeader == null)
            {
                return NotFound();
            }
            var usercityleader = await _context.UserCityLeader.FindAsync(id);
            if (usercityleader == null)
            {
                return NotFound();
            }

            _context.UserCityLeader.Remove(usercityleader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCityLeaderExists(Guid id)
        {
            return (_context.UserCityLeader?.Any(e => e.UserCityLeaderId == id)).GetValueOrDefault();
        }
	}
}

