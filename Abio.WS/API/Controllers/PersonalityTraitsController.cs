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
	
	public class PersonalityTraitsController : ControllerBase
	{
		private readonly AbioContext _context;

		public PersonalityTraitsController(AbioContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalityTrait>>> GetPersonalityTrait()
        {
          if (_context.PersonalityTrait == null)
          {
              return NotFound();
          }
            return await _context.PersonalityTrait.ToListAsync();
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<PersonalityTrait>> GetPersonalityTrait(int id)
		{
          if (_context.PersonalityTrait == null)
          {
              return NotFound();
          }
            var personalitytrait = await _context.PersonalityTrait.FindAsync(id);

            if (personalitytrait  == null)
            {
                return NotFound();
            }

            return personalitytrait;
        }

		[HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalityTrait(int id, PersonalityTrait personalitytrait)
        {
            if (id != personalitytrait.PersonalityTraitId)
            {
                return BadRequest();
            }

            _context.Entry(personalitytrait).State = EntityState.Modified;

            try
            {
                  
                  
                  
                  
                  

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalityTraitExists(id))
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
        public async Task<ActionResult<PersonalityTrait>> PostPersonalityTrait(PersonalityTrait personalitytrait)
        {
          if (_context.PersonalityTrait == null)
          {
              return Problem("Entity set 'AbioContext.PersonalityTrait'  is null.");
          }
            _context.PersonalityTrait.Add(personalitytrait);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonalityTraitExists(personalitytrait.PersonalityTraitId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonalityTrait", new { id = personalitytrait.PersonalityTraitId }, personalitytrait);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalityTrait(int id)
        {
            if (_context.PersonalityTrait == null)
            {
                return NotFound();
            }
            var personalitytrait = await _context.PersonalityTrait.FindAsync(id);
            if (personalitytrait == null)
            {
                return NotFound();
            }

            _context.PersonalityTrait.Remove(personalitytrait);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalityTraitExists(int id)
        {
            return (_context.PersonalityTrait?.Any(e => e.PersonalityTraitId == id)).GetValueOrDefault();
        }
	}
}

