using Abio.Library.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.Controllers
{
    public partial class ResourceInventorysController
    {
        [HttpGet("\\user\\{id}")]
        public async Task<ActionResult<List<ResourceInventory>>> GetResourceInventoryByUserId(Guid id)
        {
            if (_context.ResourceInventory == null)
            {
                return NotFound();
            }
            var resourceinventory = await _context.ResourceInventory.Where(p => p.UserId == id).ToArrayAsync();
            var r = resourceinventory.ToList(); 
            if (resourceinventory == null)
            {
                return NotFound();
            }

            return r;
        }
    }
}
