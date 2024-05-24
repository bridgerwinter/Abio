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
	
	public class ConstructedBuildingsController : ControllerBase
	{
		private readonly AbioContext _context;

		public ConstructedBuildingsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructedBuilding>>> GetConstructedBuilding()
        {
          if (_context.ConstructedBuilding == null)
          {
              return NotFound();
          }
            return await _context.ConstructedBuilding.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ConstructedBuilding>> GetConstructedBuilding(Guid id)
		{
          if (_context.ConstructedBuilding == null)
          {
              return NotFound();
          }
            var constructedbuilding = await _context.ConstructedBuilding.FindAsync(id);

            if (constructedbuilding  == null)
            {
                return NotFound();
            }

            return constructedbuilding;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutConstructedBuilding(Guid id, ConstructedBuilding constructedbuilding)
        {
            if (id != constructedbuilding.ConstructedBuildingId)
            {
                return BadRequest();
            }

            _context.Entry(constructedbuilding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructedBuildingExists(id))
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
        public async Task<ActionResult<ConstructedBuilding>> PostConstructedBuilding(ConstructedBuilding constructedbuilding)
        {
          if (_context.ConstructedBuilding == null)
          {
              return Problem("Entity set 'AbioContext.ConstructedBuilding'  is null.");
          }
            _context.ConstructedBuilding.Add(constructedbuilding);
            try
            {
                  constructedbuilding.ConstructedBuildingId = Guid.NewGuid();
                  if (this.ConstructedBuildingExists(constructedbuilding.ConstructedBuildingId))
                  {
                    constructedbuilding.ConstructedBuildingId = Guid.NewGuid();
                  }                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConstructedBuildingExists(constructedbuilding.ConstructedBuildingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConstructedBuilding", new { id = constructedbuilding.ConstructedBuildingId }, constructedbuilding);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructedBuilding(Guid id)
        {
            if (_context.ConstructedBuilding == null)
            {
                return NotFound();
            }
            var constructedbuilding = await _context.ConstructedBuilding.FindAsync(id);
            if (constructedbuilding == null)
            {
                return NotFound();
            }

            _context.ConstructedBuilding.Remove(constructedbuilding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructedBuildingExists(Guid id)
        {
            return (_context.ConstructedBuilding?.Any(e => e.ConstructedBuildingId == id)).GetValueOrDefault();
        }
	}
}

