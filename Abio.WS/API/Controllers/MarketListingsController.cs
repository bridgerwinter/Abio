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
    public class MarketListingsController : ControllerBase
    {
        private readonly AbioContext _context;

        public MarketListingsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/MarketListings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketListing>>> GetMarketListing()
        {
          if (_context.MarketListing == null)
          {
              return NotFound();
          }
            return await _context.MarketListing.ToListAsync();
        }

        // GET: api/MarketListings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketListing>> GetMarketListing(Guid id)
        {
          if (_context.MarketListing == null)
          {
              return NotFound();
          }
            var marketListing = await _context.MarketListing.FindAsync(id);

            if (marketListing == null)
            {
                return NotFound();
            }

            return marketListing;
        }

        // PUT: api/MarketListings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketListing(Guid id, MarketListing marketListing)
        {
            if (id != marketListing.MarketListingId)
            {
                return BadRequest();
            }

            _context.Entry(marketListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketListingExists(id))
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

        // POST: api/MarketListings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MarketListing>> PostMarketListing(MarketListing marketListing)
        {
          if (_context.MarketListing == null)
          {
              return Problem("Entity set 'AbioContext.MarketListing'  is null.");
          }
            _context.MarketListing.Add(marketListing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketListingExists(marketListing.MarketListingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarketListing", new { id = marketListing.MarketListingId }, marketListing);
        }

        // DELETE: api/MarketListings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketListing(Guid id)
        {
            if (_context.MarketListing == null)
            {
                return NotFound();
            }
            var marketListing = await _context.MarketListing.FindAsync(id);
            if (marketListing == null)
            {
                return NotFound();
            }

            _context.MarketListing.Remove(marketListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketListingExists(Guid id)
        {
            return (_context.MarketListing?.Any(e => e.MarketListingId == id)).GetValueOrDefault();
        }
    }
}
