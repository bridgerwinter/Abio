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
	
	public class EmotionsController : ControllerBase
	{
		private readonly AbioContext _context;

		public EmotionsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emotion>>> GetEmotion()
        {
          if (_context.Emotion == null)
          {
              return NotFound();
          }
            return await _context.Emotion.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<Emotion>> GetEmotion(int id)
		{
          if (_context.Emotion == null)
          {
              return NotFound();
          }
            var emotion = await _context.Emotion.FindAsync(id);

            if (emotion  == null)
            {
                return NotFound();
            }

            return emotion;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutEmotion(int id, Emotion emotion)
        {
            if (id != emotion.EmotionId)
            {
                return BadRequest();
            }

            _context.Entry(emotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmotionExists(id))
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
        public async Task<ActionResult<Emotion>> PostEmotion(Emotion emotion)
        {
          if (_context.Emotion == null)
          {
              return Problem("Entity set 'AbioContext.Emotion'  is null.");
          }
            _context.Emotion.Add(emotion);
            try
            {
                  
                  
                  
                  
                                  await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmotionExists(emotion.EmotionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmotion", new { id = emotion.EmotionId }, emotion);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmotion(int id)
        {
            if (_context.Emotion == null)
            {
                return NotFound();
            }
            var emotion = await _context.Emotion.FindAsync(id);
            if (emotion == null)
            {
                return NotFound();
            }

            _context.Emotion.Remove(emotion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmotionExists(int id)
        {
            return (_context.Emotion?.Any(e => e.EmotionId == id)).GetValueOrDefault();
        }
	}
}

