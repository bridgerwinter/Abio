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
    public class ItemInventoriesController : ControllerBase
    {
        private readonly AbioContext _context;

        public ItemInventoriesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/ItemInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemInventory>>> GetItemInventory()
        {
          if (_context.ItemInventory == null)
          {
              return NotFound();
          }
            return await _context.ItemInventory.ToListAsync();
        }

        // GET: api/ItemInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemInventory>> GetItemInventory(Guid id)
        {
          if (_context.ItemInventory == null)
          {
              return NotFound();
          }
            var itemInventory = await _context.ItemInventory.FindAsync(id);

            if (itemInventory == null)
            {
                return NotFound();
            }

            return itemInventory;
        }

        // PUT: api/ItemInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemInventory(Guid id, ItemInventory itemInventory)
        {
            if (id != itemInventory.ItemInventoryId)
            {
                return BadRequest();
            }

            _context.Entry(itemInventory).State = EntityState.Modified;

            try
            {
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

        // POST: api/ItemInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemInventory>> PostItemInventory(ItemInventory itemInventory)
        {
          if (_context.ItemInventory == null)
          {
              return Problem("Entity set 'AbioContext.ItemInventory'  is null.");
          }
            _context.ItemInventory.Add(itemInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemInventoryExists(itemInventory.ItemInventoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItemInventory", new { id = itemInventory.ItemInventoryId }, itemInventory);
        }

        // DELETE: api/ItemInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemInventory(Guid id)
        {
            if (_context.ItemInventory == null)
            {
                return NotFound();
            }
            var itemInventory = await _context.ItemInventory.FindAsync(id);
            if (itemInventory == null)
            {
                return NotFound();
            }

            _context.ItemInventory.Remove(itemInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemInventoryExists(Guid id)
        {
            return (_context.ItemInventory?.Any(e => e.ItemInventoryId == id)).GetValueOrDefault();
        }
    }
}
