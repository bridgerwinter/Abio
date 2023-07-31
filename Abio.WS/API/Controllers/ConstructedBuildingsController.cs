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
    public class ConstructedBuildingsController : ControllerBase
    {
        private readonly AbioContext _context;

        public ConstructedBuildingsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/ConstructedBuildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructedBuilding>>> GetConstructedBuilding()
        {
          if (_context.ConstructedBuilding == null)
          {
              return NotFound();
          }
            return await _context.ConstructedBuilding.ToListAsync();
        }

        // GET: api/ConstructedBuildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructedBuilding>> GetConstructedBuilding(Guid id)
        {
          if (_context.ConstructedBuilding == null)
          {
              return NotFound();
          }
            var constructedBuilding = await _context.ConstructedBuilding.FindAsync(id);

            if (constructedBuilding == null)
            {
                return NotFound();
            }

            return constructedBuilding;
        }

        // PUT: api/ConstructedBuildings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructedBuilding(Guid id, ConstructedBuilding constructedBuilding)
        {
            if (id != constructedBuilding.ConstructedBuildingId)
            {
                return BadRequest();
            }

            _context.Entry(constructedBuilding).State = EntityState.Modified;

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

        // POST: api/ConstructedBuildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructedBuilding>> PostConstructedBuilding(ConstructedBuilding constructedBuilding)
        {
          if (_context.ConstructedBuilding == null)
          {
              return Problem("Entity set 'AbioContext.ConstructedBuilding'  is null.");
          }
            _context.ConstructedBuilding.Add(constructedBuilding);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConstructedBuildingExists(constructedBuilding.ConstructedBuildingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConstructedBuilding", new { id = constructedBuilding.ConstructedBuildingId }, constructedBuilding);
        }

        // DELETE: api/ConstructedBuildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructedBuilding(Guid id)
        {
            if (_context.ConstructedBuilding == null)
            {
                return NotFound();
            }
            var constructedBuilding = await _context.ConstructedBuilding.FindAsync(id);
            if (constructedBuilding == null)
            {
                return NotFound();
            }

            _context.ConstructedBuilding.Remove(constructedBuilding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructedBuildingExists(Guid id)
        {
            return (_context.ConstructedBuilding?.Any(e => e.ConstructedBuildingId == id)).GetValueOrDefault();
        }
    }
}
