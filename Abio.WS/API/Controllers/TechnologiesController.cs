﻿using System;
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
    public class TechnologiesController : ControllerBase
    {
        private readonly AbioContext _context;

        public TechnologiesController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/Technologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologies()
        {
          if (_context.Technologies == null)
          {
              return NotFound();
          }
            return await _context.Technologies.ToListAsync();
        }

        // GET: api/Technologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
          if (_context.Technologies == null)
          {
              return NotFound();
          }
            var technology = await _context.Technologies.FindAsync(id);

            if (technology == null)
            {
                return NotFound();
            }

            return technology;
        }

        // PUT: api/Technologies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnology(int id, Technology technology)
        {
            if (id != technology.TechnologyId)
            {
                return BadRequest();
            }

            _context.Entry(technology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologyExists(id))
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

        // POST: api/Technologies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
        {
          if (_context.Technologies == null)
          {
              return Problem("Entity set 'AbioContext.Technologies'  is null.");
          }
            _context.Technologies.Add(technology);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TechnologyExists(technology.TechnologyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTechnology", new { id = technology.TechnologyId }, technology);
        }

        // DELETE: api/Technologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            if (_context.Technologies == null)
            {
                return NotFound();
            }
            var technology = await _context.Technologies.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }

            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnologyExists(int id)
        {
            return (_context.Technologies?.Any(e => e.TechnologyId == id)).GetValueOrDefault();
        }
    }
}
