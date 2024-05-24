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
	
	public class UserCitysController : ControllerBase
	{
		private readonly AbioContext _context;

		public UserCitysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCity>>> GetUserCity()
        {
          if (_context.UserCity == null)
          {
              return NotFound();
          }
            return await _context.UserCity.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<UserCity>> GetUserCity(Guid id)
		{
          if (_context.UserCity == null)
          {
              return NotFound();
          }
            var usercity = await _context.UserCity.FindAsync(id);

            if (usercity  == null)
            {
                return NotFound();
            }

            return usercity;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutUserCity(Guid id, UserCity usercity)
        {
            if (id != usercity.UserCityId)
            {
                return BadRequest();
            }

            _context.Entry(usercity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCityExists(id))
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
        public async Task<ActionResult<UserCity>> PostUserCity(UserCity usercity)
        {
          if (_context.UserCity == null)
          {
              return Problem("Entity set 'AbioContext.UserCity'  is null.");
          }
            _context.UserCity.Add(usercity);
            try
            {
                  usercity.UserCityId = Guid.NewGuid();
                  if (this.UserCityExists(usercity.UserCityId))
                  {
                    usercity.UserCityId = Guid.NewGuid();
                  }                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCityExists(usercity.UserCityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCity", new { id = usercity.UserCityId }, usercity);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCity(Guid id)
        {
            if (_context.UserCity == null)
            {
                return NotFound();
            }
            var usercity = await _context.UserCity.FindAsync(id);
            if (usercity == null)
            {
                return NotFound();
            }

            _context.UserCity.Remove(usercity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCityExists(Guid id)
        {
            return (_context.UserCity?.Any(e => e.UserCityId == id)).GetValueOrDefault();
        }
	}
}

