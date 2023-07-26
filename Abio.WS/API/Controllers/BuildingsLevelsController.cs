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
    public class BuildingsLevelsController : ControllerBase
    {
        private readonly AbioContext _context;

        public BuildingsLevelsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/BuildingsLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingsLevel>>> GetBuildingsLevels()
        {
          if (_context.BuildingsLevels == null)
          {
              return NotFound();
          }
            return await _context.BuildingsLevels.ToListAsync();
        }

        // GET: api/BuildingsLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingsLevel>> GetBuildingsLevel(int id)
        {
          if (_context.BuildingsLevels == null)
          {
              return NotFound();
          }
            var buildingsLevel = await _context.BuildingsLevels.FindAsync(id);

            if (buildingsLevel == null)
            {
                return NotFound();
            }

            return buildingsLevel;
        }

        // PUT: api/BuildingsLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingsLevel(int id, BuildingsLevel buildingsLevel)
        {
            if (id != buildingsLevel.BuildingLevelId)
            {
                return BadRequest();
            }

            _context.Entry(buildingsLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingsLevelExists(id))
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

        // POST: api/BuildingsLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingsLevel>> PostBuildingsLevel(BuildingsLevel buildingsLevel)
        {
          if (_context.BuildingsLevels == null)
          {
              return Problem("Entity set 'AbioContext.BuildingsLevels'  is null.");
          }
            _context.BuildingsLevels.Add(buildingsLevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingsLevelExists(buildingsLevel.BuildingLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuildingsLevel", new { id = buildingsLevel.BuildingLevelId }, buildingsLevel);
        }

        // DELETE: api/BuildingsLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingsLevel(int id)
        {
            if (_context.BuildingsLevels == null)
            {
                return NotFound();
            }
            var buildingsLevel = await _context.BuildingsLevels.FindAsync(id);
            if (buildingsLevel == null)
            {
                return NotFound();
            }

            _context.BuildingsLevels.Remove(buildingsLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingsLevelExists(int id)
        {
            return (_context.BuildingsLevels?.Any(e => e.BuildingLevelId == id)).GetValueOrDefault();
        }
    }
}
