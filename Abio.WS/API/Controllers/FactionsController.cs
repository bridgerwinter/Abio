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
    public class FactionsController : ControllerBase
    {
        private readonly AbioContext _context;

        public FactionsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/Factions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faction>>> GetFaction()
        {
          if (_context.Faction == null)
          {
              return NotFound();
          }
            return await _context.Faction.ToListAsync();
        }

        // GET: api/Factions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faction>> GetFaction(int id)
        {
          if (_context.Faction == null)
          {
              return NotFound();
          }
            var faction = await _context.Faction.FindAsync(id);

            if (faction == null)
            {
                return NotFound();
            }

            return faction;
        }

        // PUT: api/Factions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaction(int id, Faction faction)
        {
            if (id != faction.FactionId)
            {
                return BadRequest();
            }

            _context.Entry(faction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactionExists(id))
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

        // POST: api/Factions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Faction>> PostFaction(Faction faction)
        {
          if (_context.Faction == null)
          {
              return Problem("Entity set 'AbioContext.Faction'  is null.");
          }
            _context.Faction.Add(faction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FactionExists(faction.FactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFaction", new { id = faction.FactionId }, faction);
        }

        // DELETE: api/Factions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaction(int id)
        {
            if (_context.Faction == null)
            {
                return NotFound();
            }
            var faction = await _context.Faction.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }

            _context.Faction.Remove(faction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactionExists(int id)
        {
            return (_context.Faction?.Any(e => e.FactionId == id)).GetValueOrDefault();
        }
    }
}
