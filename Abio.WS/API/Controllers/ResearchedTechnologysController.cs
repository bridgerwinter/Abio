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
	
	public class ResearchedTechnologysController : ControllerBase
	{
		private readonly AbioContext _context;

		public ResearchedTechnologysController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchedTechnology>>> GetResearchedTechnology()
        {
          if (_context.ResearchedTechnology == null)
          {
              return NotFound();
          }
            return await _context.ResearchedTechnology.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ResearchedTechnology>> GetResearchedTechnology(Guid id)
		{
          if (_context.ResearchedTechnology == null)
          {
              return NotFound();
          }
            var researchedtechnology = await _context.ResearchedTechnology.FindAsync(id);

            if (researchedtechnology  == null)
            {
                return NotFound();
            }

            return researchedtechnology;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutResearchedTechnology(Guid id, ResearchedTechnology researchedtechnology)
        {
            if (id != researchedtechnology.ResearchedTechnologyId)
            {
                return BadRequest();
            }

            _context.Entry(researchedtechnology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchedTechnologyExists(id))
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
        public async Task<ActionResult<ResearchedTechnology>> PostResearchedTechnology(ResearchedTechnology researchedtechnology)
        {
          if (_context.ResearchedTechnology == null)
          {
              return Problem("Entity set 'AbioContext.ResearchedTechnology'  is null.");
          }
            _context.ResearchedTechnology.Add(researchedtechnology);
            try
            {
                researchedtechnology.ResearchedTechnologyId = Guid.NewGuid();
                if (this.ResearchedTechnologyExists(researchedtechnology.ResearchedTechnologyId))
                {
                  researchedtechnology.ResearchedTechnologyId = Guid.NewGuid();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResearchedTechnologyExists(researchedtechnology.ResearchedTechnologyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResearchedTechnology", new { id = researchedtechnology.ResearchedTechnologyId }, researchedtechnology);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchedTechnology(Guid id)
        {
            if (_context.ResearchedTechnology == null)
            {
                return NotFound();
            }
            var researchedtechnology = await _context.ResearchedTechnology.FindAsync(id);
            if (researchedtechnology == null)
            {
                return NotFound();
            }

            _context.ResearchedTechnology.Remove(researchedtechnology);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchedTechnologyExists(Guid id)
        {
            return (_context.ResearchedTechnology?.Any(e => e.ResearchedTechnologyId == id)).GetValueOrDefault();
        }
	}
}

