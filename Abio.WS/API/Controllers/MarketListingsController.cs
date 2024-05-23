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
	
	public class MarketListingsController : ControllerBase
	{
		private readonly AbioContext _context;

		public MarketListingsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketListing>>> GetMarketListing()
        {
          if (_context.MarketListing == null)
          {
              return NotFound();
          }
            return await _context.MarketListing.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<MarketListing>> GetMarketListing(Guid id)
		{
          if (_context.MarketListing == null)
          {
              return NotFound();
          }
            var marketlisting = await _context.MarketListing.FindAsync(id);

            if (marketlisting  == null)
            {
                return NotFound();
            }

            return marketlisting;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutMarketListing(Guid id, MarketListing marketlisting)
        {
            if (id != marketlisting.MarketListingId)
            {
                return BadRequest();
            }

            _context.Entry(marketlisting).State = EntityState.Modified;

            try
            {
                  marketlisting.MarketListingId = Guid.NewGuid();
                  if (this.MarketListingExists(marketlisting.MarketListingId))
                  {
                    marketlisting.MarketListingId = Guid.NewGuid();
                  }

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

        [HttpPost]
        public async Task<ActionResult<MarketListing>> PostMarketListing(MarketListing marketlisting)
        {
          if (_context.MarketListing == null)
          {
              return Problem("Entity set 'AbioContext.MarketListing'  is null.");
          }
            _context.MarketListing.Add(marketlisting);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketListingExists(marketlisting.MarketListingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarketListing", new { id = marketlisting.MarketListingId }, marketlisting);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketListing(Guid id)
        {
            if (_context.MarketListing == null)
            {
                return NotFound();
            }
            var marketlisting = await _context.MarketListing.FindAsync(id);
            if (marketlisting == null)
            {
                return NotFound();
            }

            _context.MarketListing.Remove(marketlisting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketListingExists(Guid id)
        {
            return (_context.MarketListing?.Any(e => e.MarketListingId == id)).GetValueOrDefault();
        }
	}
}

