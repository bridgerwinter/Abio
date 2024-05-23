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
	
	public class FriendsController : ControllerBase
	{
		private readonly AbioContext _context;

		public FriendsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriend()
        {
          if (_context.Friend == null)
          {
              return NotFound();
          }
            return await _context.Friend.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Friend>> GetFriend(Guid id)
		{
          if (_context.Friend == null)
          {
              return NotFound();
          }
            var friend = await _context.Friend.FindAsync(id);

            if (friend  == null)
            {
                return NotFound();
            }

            return friend;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutFriend(Guid id, Friend friend)
        {
            if (id != friend.UserId)
            {
                return BadRequest();
            }

            _context.Entry(friend).State = EntityState.Modified;

            try
            {
                  friend.FriendId = Guid.NewGuid();
                  if (this.FriendExists(friend.FriendId))
                  {
                    friend.FriendId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(id))
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
        public async Task<ActionResult<Friend>> PostFriend(Friend friend)
        {
          if (_context.Friend == null)
          {
              return Problem("Entity set 'AbioContext.Friend'  is null.");
          }
            _context.Friend.Add(friend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FriendExists(friend.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFriend", new { id = friend.UserId }, friend);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend(Guid id)
        {
            if (_context.Friend == null)
            {
                return NotFound();
            }
            var friend = await _context.Friend.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }

            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FriendExists(Guid id)
        {
            return (_context.Friend?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
	}
}

