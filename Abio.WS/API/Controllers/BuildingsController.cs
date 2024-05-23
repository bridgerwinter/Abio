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
	
	public class BuildingsController : ControllerBase
	{
		private readonly AbioContext _context;

		public BuildingsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
          if (_context.Building == null)
          {
              return NotFound();
          }
            return await _context.Building.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Building>> GetBuilding(int id)
		{
          if (_context.Building == null)
          {
              return NotFound();
          }
            var building = await _context.Building.FindAsync(id);

            if (building  == null)
            {
                return NotFound();
            }

            return building;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(int id, Building building)
        {
            if (id != building.BuildingId)
            {
                return BadRequest();
            }

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                  
                  
                  
                  
                  

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
          if (_context.Building == null)
          {
              return Problem("Entity set 'AbioContext.Building'  is null.");
          }
            _context.Building.Add(building);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingExists(building.BuildingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuilding", new { id = building.BuildingId }, building);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            if (_context.Building == null)
            {
                return NotFound();
            }
            var building = await _context.Building.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            _context.Building.Remove(building);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingExists(int id)
        {
            return (_context.Building?.Any(e => e.BuildingId == id)).GetValueOrDefault();
        }
	}
}

