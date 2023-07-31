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
    public class MarketsController : ControllerBase
    {
        private readonly AbioContext _context;

        public MarketsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/Markets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Market>>> GetMarkets()
        {
          if (_context.Markets == null)
          {
              return NotFound();
          }
            return await _context.Markets.ToListAsync();
        }

        // GET: api/Markets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Market>> GetMarket(Guid id)
        {
          if (_context.Markets == null)
          {
              return NotFound();
          }
            var market = await _context.Markets.FindAsync(id);

            if (market == null)
            {
                return NotFound();
            }

            return market;
        }

        // PUT: api/Markets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarket(Guid id, Market market)
        {
            if (id != market.MarketId)
            {
                return BadRequest();
            }

            _context.Entry(market).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketExists(id))
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

        // POST: api/Markets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Market>> PostMarket(Market market)
        {
          if (_context.Markets == null)
          {
              return Problem("Entity set 'AbioContext.Markets'  is null.");
          }
            _context.Markets.Add(market);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketExists(market.MarketId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarket", new { id = market.MarketId }, market);
        }

        // DELETE: api/Markets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarket(Guid id)
        {
            if (_context.Markets == null)
            {
                return NotFound();
            }
            var market = await _context.Markets.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketExists(Guid id)
        {
            return (_context.Markets?.Any(e => e.MarketId == id)).GetValueOrDefault();
        }
    }
}
