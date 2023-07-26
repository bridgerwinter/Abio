﻿using System;
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
    public class ResearchedTechnologiesController : ControllerBase
    {
        private readonly AbioContext _context;

        public ResearchedTechnologiesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/ResearchedTechnologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchedTechnology>>> GetResearchedTechnologies()
        {
          if (_context.ResearchedTechnologies == null)
          {
              return NotFound();
          }
            return await _context.ResearchedTechnologies.ToListAsync();
        }

        // GET: api/ResearchedTechnologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchedTechnology>> GetResearchedTechnology(Guid? id)
        {
          if (_context.ResearchedTechnologies == null)
          {
              return NotFound();
          }
            var researchedTechnology = await _context.ResearchedTechnologies.FindAsync(id);

            if (researchedTechnology == null)
            {
                return NotFound();
            }

            return researchedTechnology;
        }

        // PUT: api/ResearchedTechnologies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchedTechnology(Guid? id, ResearchedTechnology researchedTechnology)
        {
            if (id != researchedTechnology.ResearchedTechnologyId)
            {
                return BadRequest();
            }

            _context.Entry(researchedTechnology).State = EntityState.Modified;

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

        // POST: api/ResearchedTechnologies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResearchedTechnology>> PostResearchedTechnology(ResearchedTechnology researchedTechnology)
        {
          if (_context.ResearchedTechnologies == null)
          {
              return Problem("Entity set 'AbioContext.ResearchedTechnologies'  is null.");
          }
            _context.ResearchedTechnologies.Add(researchedTechnology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearchedTechnology", new { id = researchedTechnology.ResearchedTechnologyId }, researchedTechnology);
        }

        // DELETE: api/ResearchedTechnologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchedTechnology(Guid? id)
        {
            if (_context.ResearchedTechnologies == null)
            {
                return NotFound();
            }
            var researchedTechnology = await _context.ResearchedTechnologies.FindAsync(id);
            if (researchedTechnology == null)
            {
                return NotFound();
            }

            _context.ResearchedTechnologies.Remove(researchedTechnology);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchedTechnologyExists(Guid? id)
        {
            return (_context.ResearchedTechnologies?.Any(e => e.ResearchedTechnologyId == id)).GetValueOrDefault();
        }
    }
}
