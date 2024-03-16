using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data;
using ReceptionApp.Models;

namespace ReceptionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptsController : ControllerBase
    {
        private readonly ReceptionAppDbContext _context;

        public ReceptsController(ReceptionAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Recepts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recept>>> GetReceptions()
        {
            return await _context.Receptions.ToListAsync();
        }

        // GET: api/Recepts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recept>> GetRecept(int id)
        {
            var recept = await _context.Receptions.FindAsync(id);

            if (recept == null)
            {
                return NotFound();
            }

            return recept;
        }

        // PUT: api/Recepts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecept(int id, Recept recept)
        {
            if (id != recept.Id)
            {
                return BadRequest();
            }

            _context.Entry(recept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptExists(id))
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

        // POST: api/Recepts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recept>> PostRecept(Recept recept)
        {
            _context.Receptions.Add(recept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecept", new { id = recept.Id }, recept);
        }

        // DELETE: api/Recepts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecept(int id)
        {
            var recept = await _context.Receptions.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }

            _context.Receptions.Remove(recept);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceptExists(int id)
        {
            return _context.Receptions.Any(e => e.Id == id);
        }
    }
}
