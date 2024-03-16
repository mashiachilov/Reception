using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data;
using ReceptionApp.Models;
using ReceptionApp.Repositories;

namespace ReceptionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptsController : ControllerBase
    {
        private readonly ReceptionAppDbContext _context;
        private readonly IReceptionRepository receptionRepository;

        public ReceptsController(IReceptionRepository receptionRepository)
        {
            this.receptionRepository = receptionRepository;
        }

        // GET: api/Recepts
        [HttpGet]
        public async Task<IEnumerable<Recept>> GetReceptions()
        {
            return await receptionRepository.GetAllRecept();
        }

        // GET: api/Recepts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recept>> GetRecept(int id)
        {
            var recept = await receptionRepository.GetSingleRecept(id);

            if(recept == null)
            {
                return NotFound();
            }
            return Ok(recept);
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

            await receptionRepository.UpdateRecept(recept);
            return NoContent();
        }

        // POST: api/Recepts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recept>> PostRecept(Recept recept)
        {
            await receptionRepository.CreateRecept(recept);

            return CreatedAtAction("GetRecept", new { id = recept.Id }, recept);
        }

        // DELETE: api/Recepts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecept(int id)
        {
            await receptionRepository.DeleteRecept(id);
            return NoContent();
        }
    }
}
