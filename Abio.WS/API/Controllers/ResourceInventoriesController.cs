using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abio.WS.API.DatabaseModels;

namespace Abio.WS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceInventoriesController : ControllerBase
    {
        private readonly AbioContext _context;

        public ResourceInventoriesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/ResourceInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceInventory>>> GetResourceInventories()
        {
          if (_context.ResourceInventories == null)
          {
              return NotFound();
          }
            return await _context.ResourceInventories.ToListAsync();
        }

        // GET: api/ResourceInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceInventory>> GetResourceInventory(Guid id)
        {
          if (_context.ResourceInventories == null)
          {
              return NotFound();
          }
            var resourceInventory = await _context.ResourceInventories.FindAsync(id);

            if (resourceInventory == null)
            {
                return NotFound();
            }

            return resourceInventory;
        }

        // PUT: api/ResourceInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResourceInventory(Guid id, ResourceInventory resourceInventory)
        {
            if (id != resourceInventory.ResourceInventoryId)
            {
                return BadRequest();
            }

            _context.Entry(resourceInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceInventoryExists(id))
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

        // POST: api/ResourceInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResourceInventory>> PostResourceInventory(ResourceInventory resourceInventory)
        {
          if (_context.ResourceInventories == null)
          {
              return Problem("Entity set 'AbioContext.ResourceInventories'  is null.");
          }
            _context.ResourceInventories.Add(resourceInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResourceInventoryExists(resourceInventory.ResourceInventoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResourceInventory", new { id = resourceInventory.ResourceInventoryId }, resourceInventory);
        }

        // DELETE: api/ResourceInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceInventory(Guid id)
        {
            if (_context.ResourceInventories == null)
            {
                return NotFound();
            }
            var resourceInventory = await _context.ResourceInventories.FindAsync(id);
            if (resourceInventory == null)
            {
                return NotFound();
            }

            _context.ResourceInventories.Remove(resourceInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceInventoryExists(Guid id)
        {
            return (_context.ResourceInventories?.Any(e => e.ResourceInventoryId == id)).GetValueOrDefault();
        }
    }
}
