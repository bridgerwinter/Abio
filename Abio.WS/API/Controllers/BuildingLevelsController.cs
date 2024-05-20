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
	
	public class BuildingLevelsController : ControllerBase
	{
		private readonly AbioContext _context;

		public BuildingLevelsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingLevel>>> GetBuildingLevel()
        {
          if (_context.BuildingLevel == null)
          {
              return NotFound();
          }
            return await _context.BuildingLevel.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<BuildingLevel>> GetBuildingLevel(int id)
		{
          if (_context.BuildingLevel == null)
          {
              return NotFound();
          }
            var buildinglevel = await _context.BuildingLevel.FindAsync(id);

            if (buildinglevel  == null)
            {
                return NotFound();
            }

            return buildinglevel;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingLevel(int id, BuildingLevel buildinglevel)
        {
            if (id != buildinglevel.BuildingLevelId)
            {
                return BadRequest();
            }

            _context.Entry(buildinglevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingLevelExists(id))
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
        public async Task<ActionResult<BuildingLevel>> PostBuildingLevel(BuildingLevel buildinglevel)
        {
          if (_context.BuildingLevel == null)
          {
              return Problem("Entity set 'AbioContext.BuildingLevel'  is null.");
          }
            _context.BuildingLevel.Add(buildinglevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingLevelExists(buildinglevel.BuildingLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuildingLevel", new { id = buildinglevel.BuildingLevelId }, buildinglevel);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingLevel(int id)
        {
            if (_context.BuildingLevel == null)
            {
                return NotFound();
            }
            var buildinglevel = await _context.BuildingLevel.FindAsync(id);
            if (buildinglevel == null)
            {
                return NotFound();
            }

            _context.BuildingLevel.Remove(buildinglevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingLevelExists(int id)
        {
            return (_context.BuildingLevel?.Any(e => e.BuildingLevelId == id)).GetValueOrDefault();
        }
	}
}

