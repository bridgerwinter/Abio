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
	
	public partial class ResourceInventorysController : ControllerBase
	{
		private readonly AbioContext _context;

		public ResourceInventorysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceInventory>>> GetResourceInventory()
        {
          if (_context.ResourceInventory == null)
          {
              return NotFound();
          }
            return await _context.ResourceInventory.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ResourceInventory>> GetResourceInventory(Guid id)
		{
          if (_context.ResourceInventory == null)
          {
              return NotFound();
          }
            var resourceinventory = await _context.ResourceInventory.FindAsync(id);

            if (resourceinventory  == null)
            {
                return NotFound();
            }

            return resourceinventory;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutResourceInventory(Guid id, ResourceInventory resourceinventory)
        {
            if (id != resourceinventory.ResourceInventoryId)
            {
                return BadRequest();
            }

            _context.Entry(resourceinventory).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<ResourceInventory>> PostResourceInventory(ResourceInventory resourceinventory)
        {
          if (_context.ResourceInventory == null)
          {
              return Problem("Entity set 'AbioContext.ResourceInventory'  is null.");
          }
            _context.ResourceInventory.Add(resourceinventory);
            try
            {
                resourceinventory.ResourceInventoryId = Guid.NewGuid();
                if (this.ResourceInventoryExists(resourceinventory.ResourceInventoryId))
                {
                  resourceinventory.ResourceInventoryId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResourceInventoryExists(resourceinventory.ResourceInventoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResourceInventory", new { id = resourceinventory.ResourceInventoryId }, resourceinventory);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceInventory(Guid id)
        {
            if (_context.ResourceInventory == null)
            {
                return NotFound();
            }
            var resourceinventory = await _context.ResourceInventory.FindAsync(id);
            if (resourceinventory == null)
            {
                return NotFound();
            }

            _context.ResourceInventory.Remove(resourceinventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceInventoryExists(Guid id)
        {
            return (_context.ResourceInventory?.Any(e => e.ResourceInventoryId == id)).GetValueOrDefault();
        }
	}
}

