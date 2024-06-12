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
	
	public partial class ResourcesController : ControllerBase
	{
		private readonly AbioContext _context;

		public ResourcesController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        {
          if (_context.Resource == null)
          {
              return NotFound();
          }
            return await _context.Resource.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Resource>> GetResource(int id)
		{
          if (_context.Resource == null)
          {
              return NotFound();
          }
            var resource = await _context.Resource.FindAsync(id);

            if (resource  == null)
            {
                return NotFound();
            }

            return resource;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutResource(int id, Resource resource)
        {
            if (id != resource.ResourceId)
            {
                return BadRequest();
            }

            _context.Entry(resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(id))
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
        public async Task<ActionResult<Resource>> PostResource(Resource resource)
        {
          if (_context.Resource == null)
          {
              return Problem("Entity set 'AbioContext.Resource'  is null.");
          }
            _context.Resource.Add(resource);
            try
            {
                
                
                
                
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResourceExists(resource.ResourceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResource", new { id = resource.ResourceId }, resource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            if (_context.Resource == null)
            {
                return NotFound();
            }
            var resource = await _context.Resource.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            _context.Resource.Remove(resource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceExists(int id)
        {
            return (_context.Resource?.Any(e => e.ResourceId == id)).GetValueOrDefault();
        }
	}
}

