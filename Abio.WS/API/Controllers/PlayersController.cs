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
	
	public class PlayersController : ControllerBase
	{
		private readonly AbioContext _context;

		public PlayersController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
          if (_context.Player == null)
          {
              return NotFound();
          }
            return await _context.Player.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Player>> GetPlayer(Guid id)
		{
          if (_context.Player == null)
          {
              return NotFound();
          }
            var player = await _context.Player.FindAsync(id);

            if (player  == null)
            {
                return NotFound();
            }

            return player;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(Guid id, Player player)
        {
            if (id != player.UserId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
          if (_context.Player == null)
          {
              return Problem("Entity set 'AbioContext.Player'  is null.");
          }
            _context.Player.Add(player);
            try
            {
                  player.UserId = Guid.NewGuid();
                  if (this.PlayerExists(player.UserId))
                  {
                    player.UserId = Guid.NewGuid();
                  }                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayer", new { id = player.UserId }, player);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(Guid id)
        {
            return (_context.Player?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
	}
}

