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
	
	public partial class MarketsController : ControllerBase
	{
		private readonly AbioContext _context;

		public MarketsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Market>>> GetMarket()
        {
          if (_context.Market == null)
          {
              return NotFound();
          }
            return await _context.Market.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Market>> GetMarket(Guid id)
		{
          if (_context.Market == null)
          {
              return NotFound();
          }
            var market = await _context.Market.FindAsync(id);

            if (market  == null)
            {
                return NotFound();
            }

            return market;
        }

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

        [HttpPost]
        public async Task<ActionResult<Market>> PostMarket(Market market)
        {
          if (_context.Market == null)
          {
              return Problem("Entity set 'AbioContext.Market'  is null.");
          }
            _context.Market.Add(market);
            try
            {
                market.MarketId = Guid.NewGuid();
                if (this.MarketExists(market.MarketId))
                {
                  market.MarketId = Guid.NewGuid();
                }
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
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarket(Guid id)
        {
            if (_context.Market == null)
            {
                return NotFound();
            }
            var market = await _context.Market.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            _context.Market.Remove(market);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketExists(Guid id)
        {
            return (_context.Market?.Any(e => e.MarketId == id)).GetValueOrDefault();
        }
	}
}

