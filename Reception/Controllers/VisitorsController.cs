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
    public class VisitorsController : ControllerBase
    {
        private readonly IVsitorRepository _vsitorRepository;

        public VisitorsController(IVsitorRepository vsitorRepository)
        {
            _vsitorRepository = vsitorRepository;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<IEnumerable<Visitor>> GetAllVisitor()
        {
            return await _vsitorRepository.GetAllVisitor();
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetSingleVisitor(int id)
        {
            var visitor = await _vsitorRepository.GetSingleVisitor(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return Ok(visitor);
        }

        // PUT: api/Visitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _vsitorRepository.UpdateVisitor(visitor);
            }
            catch (DbUpdateConcurrencyException)
            {
                var visitorSingle = await _vsitorRepository.GetSingleVisitor(id);
                if (visitorSingle == null)
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

        // POST: api/Visitors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitor>> CreateVisitor(Visitor visitor)
        {
            await _vsitorRepository.CreateVisitor(visitor);

            return CreatedAtAction("GetVisitors", new { id = visitor.Id }, visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            await _vsitorRepository.DeleteVisitor(id);

            return NoContent();
        }
    }
}
