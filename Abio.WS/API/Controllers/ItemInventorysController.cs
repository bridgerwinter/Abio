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
	
	public class ItemInventorysController : ControllerBase
	{
		private readonly AbioContext _context;

		public ItemInventorysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemInventory>>> GetItemInventory()
        {
          if (_context.ItemInventory == null)
          {
              return NotFound();
          }
            return await _context.ItemInventory.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ItemInventory>> GetItemInventory(Guid id)
		{
          if (_context.ItemInventory == null)
          {
              return NotFound();
          }
            var iteminventory = await _context.ItemInventory.FindAsync(id);

            if (iteminventory  == null)
            {
                return NotFound();
            }

            return iteminventory;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutItemInventory(Guid id, ItemInventory iteminventory)
        {
            if (id != iteminventory.ItemInventoryId)
            {
                return BadRequest();
            }

            _context.Entry(iteminventory).State = EntityState.Modified;

            try
            {
                  iteminventory.ItemInventoryId = Guid.NewGuid();
                  if (this.ItemInventoryExists(iteminventory.ItemInventoryId))
                  {
                    iteminventory.ItemInventoryId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemInventoryExists(id))
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
        public async Task<ActionResult<ItemInventory>> PostItemInventory(ItemInventory iteminventory)
        {
          if (_context.ItemInventory == null)
          {
              return Problem("Entity set 'AbioContext.ItemInventory'  is null.");
          }
            _context.ItemInventory.Add(iteminventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemInventoryExists(iteminventory.ItemInventoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItemInventory", new { id = iteminventory.ItemInventoryId }, iteminventory);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemInventory(Guid id)
        {
            if (_context.ItemInventory == null)
            {
                return NotFound();
            }
            var iteminventory = await _context.ItemInventory.FindAsync(id);
            if (iteminventory == null)
            {
                return NotFound();
            }

            _context.ItemInventory.Remove(iteminventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemInventoryExists(Guid id)
        {
            return (_context.ItemInventory?.Any(e => e.ItemInventoryId == id)).GetValueOrDefault();
        }
	}
}

