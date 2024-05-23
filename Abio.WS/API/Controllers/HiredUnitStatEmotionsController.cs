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
	
	public class HiredUnitStatEmotionsController : ControllerBase
	{
		private readonly AbioContext _context;

		public HiredUnitStatEmotionsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiredUnitStatEmotion>>> GetHiredUnitStatEmotion()
        {
          if (_context.HiredUnitStatEmotion == null)
          {
              return NotFound();
          }
            return await _context.HiredUnitStatEmotion.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<HiredUnitStatEmotion>> GetHiredUnitStatEmotion(Guid id)
		{
          if (_context.HiredUnitStatEmotion == null)
          {
              return NotFound();
          }
            var hiredunitstatemotion = await _context.HiredUnitStatEmotion.FindAsync(id);

            if (hiredunitstatemotion  == null)
            {
                return NotFound();
            }

            return hiredunitstatemotion;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHiredUnitStatEmotion(Guid id, HiredUnitStatEmotion hiredunitstatemotion)
        {
            if (id != hiredunitstatemotion.HiredUnitStatEmotionId)
            {
                return BadRequest();
            }

            _context.Entry(hiredunitstatemotion).State = EntityState.Modified;

            try
            {
                  hiredunitstatemotion.HiredUnitStatEmotionId = Guid.NewGuid();
                  if (this.HiredUnitStatEmotionExists(hiredunitstatemotion.HiredUnitStatEmotionId))
                  {
                    hiredunitstatemotion.HiredUnitStatEmotionId = Guid.NewGuid();
                  }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiredUnitStatEmotionExists(id))
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
        public async Task<ActionResult<HiredUnitStatEmotion>> PostHiredUnitStatEmotion(HiredUnitStatEmotion hiredunitstatemotion)
        {
          if (_context.HiredUnitStatEmotion == null)
          {
              return Problem("Entity set 'AbioContext.HiredUnitStatEmotion'  is null.");
          }
            _context.HiredUnitStatEmotion.Add(hiredunitstatemotion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiredUnitStatEmotionExists(hiredunitstatemotion.HiredUnitStatEmotionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiredUnitStatEmotion", new { id = hiredunitstatemotion.HiredUnitStatEmotionId }, hiredunitstatemotion);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiredUnitStatEmotion(Guid id)
        {
            if (_context.HiredUnitStatEmotion == null)
            {
                return NotFound();
            }
            var hiredunitstatemotion = await _context.HiredUnitStatEmotion.FindAsync(id);
            if (hiredunitstatemotion == null)
            {
                return NotFound();
            }

            _context.HiredUnitStatEmotion.Remove(hiredunitstatemotion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiredUnitStatEmotionExists(Guid id)
        {
            return (_context.HiredUnitStatEmotion?.Any(e => e.HiredUnitStatEmotionId == id)).GetValueOrDefault();
        }
	}
}

