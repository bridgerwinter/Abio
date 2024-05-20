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
	
	public class ItemsController : ControllerBase
	{
		private readonly AbioContext _context;

		public ItemsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
          if (_context.Item == null)
          {
              return NotFound();
          }
            return await _context.Item.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Item>> GetItem(Guid id)
		{
          if (_context.Item == null)
          {
              return NotFound();
          }
            var item = await _context.Item.FindAsync(id);

            if (item  == null)
            {
                return NotFound();
            }

            return item;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutItem(Guid id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
          if (_context.Item == null)
          {
              return Problem("Entity set 'AbioContext.Item'  is null.");
          }
            _context.Item.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            if (_context.Item == null)
            {
                return NotFound();
            }
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(Guid id)
        {
            return (_context.Item?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
	}
}

