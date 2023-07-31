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
        public async Task<ActionResult<IEnumerable<ConstructedBuilding>>> GetConstructedBuildings()
        {
          if (_context.ConstructedBuildings == null)
          {
              return NotFound();
          }
            return await _context.ConstructedBuildings.ToListAsync();
        }

        // GET: api/ConstructedBuildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructedBuilding>> GetConstructedBuilding(Guid id)
        {
          if (_context.ConstructedBuildings == null)
          {
              return NotFound();
          }
            var constructedBuilding = await _context.ConstructedBuildings.FindAsync(id);

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
            if (id != constructedBuilding.ConstructuredBuildingId)
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
          if (_context.ConstructedBuildings == null)
          {
              return Problem("Entity set 'AbioContext.ConstructedBuildings'  is null.");
          }
            _context.ConstructedBuildings.Add(constructedBuilding);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConstructedBuildingExists(constructedBuilding.ConstructuredBuildingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConstructedBuilding", new { id = constructedBuilding.ConstructuredBuildingId }, constructedBuilding);
        }

        // DELETE: api/ConstructedBuildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructedBuilding(Guid id)
        {
            if (_context.ConstructedBuildings == null)
            {
                return NotFound();
            }
            var constructedBuilding = await _context.ConstructedBuildings.FindAsync(id);
            if (constructedBuilding == null)
            {
                return NotFound();
            }

            _context.ConstructedBuildings.Remove(constructedBuilding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructedBuildingExists(Guid id)
        {
            return (_context.ConstructedBuildings?.Any(e => e.ConstructuredBuildingId == id)).GetValueOrDefault();
        }
    }
}
