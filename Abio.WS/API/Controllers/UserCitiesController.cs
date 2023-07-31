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
    public class UserCitiesController : ControllerBase
    {
        private readonly AbioContext _context;

        public UserCitiesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/UserCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCity>>> GetUserCities()
        {
          if (_context.UserCities == null)
          {
              return NotFound();
          }
            return await _context.UserCities.ToListAsync();
        }

        // GET: api/UserCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCity>> GetUserCity(Guid id)
        {
          if (_context.UserCities == null)
          {
              return NotFound();
          }
            var userCity = await _context.UserCities.FindAsync(id);

            if (userCity == null)
            {
                return NotFound();
            }

            return userCity;
        }

        // PUT: api/UserCities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCity(Guid id, UserCity userCity)
        {
            if (id != userCity.CityId)
            {
                return BadRequest();
            }

            _context.Entry(userCity).State = EntityState.Modified;

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

        // POST: api/UserCities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCity>> PostUserCity(UserCity userCity)
        {
          if (_context.UserCities == null)
          {
              return Problem("Entity set 'AbioContext.UserCities'  is null.");
          }
            _context.UserCities.Add(userCity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCityExists(userCity.CityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCity", new { id = userCity.CityId }, userCity);
        }

        // DELETE: api/UserCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCity(Guid id)
        {
            if (_context.UserCities == null)
            {
                return NotFound();
            }
            var userCity = await _context.UserCities.FindAsync(id);
            if (userCity == null)
            {
                return NotFound();
            }

            _context.UserCities.Remove(userCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCityExists(Guid id)
        {
            return (_context.UserCities?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
