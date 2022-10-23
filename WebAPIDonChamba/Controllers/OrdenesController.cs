#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDonChamba.Models;

namespace WebAPIDonChamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly DBDonChambaContext _context;

        public OrdenesController(DBDonChambaContext context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordene>>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordene>> GetOrdene(int id)
        {
            var ordene = await _context.Ordenes.FindAsync(id);

            if (ordene == null)
            {
                return NotFound();
            }

            return ordene;
        }

        [HttpGet("byUsuarios/{id}")]
        public async Task<ActionResult<IEnumerable<Ordene>>> GetOrdenebyUsuarios(int id)
        {
            var ordene = 
                await _context.Ordenes.Where(st => st.FkIdUsuario == id)
                    .OrderByDescending(st => st.PkIdOrden).Take(30).ToListAsync();

            if (ordene == null)
            {
                return NotFound();
            } 

            return ordene;
        }

        // PUT: api/Ordenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdene(int id, Ordene ordene)
        {
            if (id != ordene.PkIdOrden)
            {
                return BadRequest();
            }

            _context.Entry(ordene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdeneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Ordenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordene>> PostOrdene(Ordene ordene)
        {
            _context.Ordenes.Add(ordene);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdene", new { id = ordene.PkIdOrden }, ordene);
        }
         

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdene(int id)
        {
            var ordene = await _context.Ordenes.FindAsync(id);
            if (ordene == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(ordene);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdeneExists(int id)
        {
            return _context.Ordenes.Any(e => e.PkIdOrden == id);
        }
    }
}
