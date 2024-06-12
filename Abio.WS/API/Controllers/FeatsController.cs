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
	
	public partial class FeatsController : ControllerBase
	{
		private readonly AbioContext _context;

		public FeatsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feat>>> GetFeat()
        {
          if (_context.Feat == null)
          {
              return NotFound();
          }
            return await _context.Feat.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Feat>> GetFeat(int id)
		{
          if (_context.Feat == null)
          {
              return NotFound();
          }
            var feat = await _context.Feat.FindAsync(id);

            if (feat  == null)
            {
                return NotFound();
            }

            return feat;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutFeat(int id, Feat feat)
        {
            if (id != feat.FeatId)
            {
                return BadRequest();
            }

            _context.Entry(feat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatExists(id))
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
        public async Task<ActionResult<Feat>> PostFeat(Feat feat)
        {
          if (_context.Feat == null)
          {
              return Problem("Entity set 'AbioContext.Feat'  is null.");
          }
            _context.Feat.Add(feat);
            try
            {
                
                
                
                
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeatExists(feat.FeatId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeat", new { id = feat.FeatId }, feat);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeat(int id)
        {
            if (_context.Feat == null)
            {
                return NotFound();
            }
            var feat = await _context.Feat.FindAsync(id);
            if (feat == null)
            {
                return NotFound();
            }

            _context.Feat.Remove(feat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeatExists(int id)
        {
            return (_context.Feat?.Any(e => e.FeatId == id)).GetValueOrDefault();
        }
	}
}

