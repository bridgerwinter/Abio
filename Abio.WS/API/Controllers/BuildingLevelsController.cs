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
    public class BuildingLevelsController : ControllerBase
    {
        private readonly AbioContext _context;

        public BuildingLevelsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/BuildingLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingLevel>>> GetBuildingLevel()
        {
          if (_context.BuildingLevel == null)
          {
              return NotFound();
          }
            return await _context.BuildingLevel.ToListAsync();
        }

        // GET: api/BuildingLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingLevel>> GetBuildingLevel(int id)
        {
          if (_context.BuildingLevel == null)
          {
              return NotFound();
          }
            var buildingLevel = await _context.BuildingLevel.FindAsync(id);

            if (buildingLevel == null)
            {
                return NotFound();
            }

            return buildingLevel;
        }

        // PUT: api/BuildingLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingLevel(int id, BuildingLevel buildingLevel)
        {
            if (id != buildingLevel.BuildingLevelId)
            {
                return BadRequest();
            }

            _context.Entry(buildingLevel).State = EntityState.Modified;

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

        // POST: api/BuildingLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingLevel>> PostBuildingLevel(BuildingLevel buildingLevel)
        {
          if (_context.BuildingLevel == null)
          {
              return Problem("Entity set 'AbioContext.BuildingLevel'  is null.");
          }
            _context.BuildingLevel.Add(buildingLevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingLevelExists(buildingLevel.BuildingLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuildingLevel", new { id = buildingLevel.BuildingLevelId }, buildingLevel);
        }

        // DELETE: api/BuildingLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingLevel(int id)
        {
            if (_context.BuildingLevel == null)
            {
                return NotFound();
            }
            var buildingLevel = await _context.BuildingLevel.FindAsync(id);
            if (buildingLevel == null)
            {
                return NotFound();
            }

            _context.BuildingLevel.Remove(buildingLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingLevelExists(int id)
        {
            return (_context.BuildingLevel?.Any(e => e.BuildingLevelId == id)).GetValueOrDefault();
        }
    }
}
