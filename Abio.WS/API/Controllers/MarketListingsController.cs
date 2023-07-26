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
    public class MarketListingsController : ControllerBase
    {
        private readonly AbioContext _context;

        public MarketListingsController(AbioContext context)
        {
            _context = context;
        }

        // GET: api/MarketListings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketListing>>> GetMarketListings()
        {
          if (_context.MarketListings == null)
          {
              return NotFound();
          }
            return await _context.MarketListings.ToListAsync();
        }

        // GET: api/MarketListings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketListing>> GetMarketListing(Guid id)
        {
          if (_context.MarketListings == null)
          {
              return NotFound();
          }
            var marketListing = await _context.MarketListings.FindAsync(id);

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
            if (id != marketListing.ListingId)
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
          if (_context.MarketListings == null)
          {
              return Problem("Entity set 'AbioContext.MarketListings'  is null.");
          }
            _context.MarketListings.Add(marketListing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketListingExists(marketListing.ListingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarketListing", new { id = marketListing.ListingId }, marketListing);
        }

        // DELETE: api/MarketListings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketListing(Guid id)
        {
            if (_context.MarketListings == null)
            {
                return NotFound();
            }
            var marketListing = await _context.MarketListings.FindAsync(id);
            if (marketListing == null)
            {
                return NotFound();
            }

            _context.MarketListings.Remove(marketListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketListingExists(Guid id)
        {
            return (_context.MarketListings?.Any(e => e.ListingId == id)).GetValueOrDefault();
        }
    }
}
