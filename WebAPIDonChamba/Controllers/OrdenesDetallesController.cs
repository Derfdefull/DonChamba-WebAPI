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
    public class OrdenesDetallesController : ControllerBase
    {
        private readonly DBDonChambaContext _context;

        public OrdenesDetallesController(DBDonChambaContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesDetalle>>> GetOrdenesDetalles()
        {
            return await _context.OrdenesDetalles.ToListAsync();
        }

        // GET: api/OrdenesDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesDetalle>> GetOrdenesDetalle(int id)
        {
            var ordenesDetalle = await _context.OrdenesDetalles.FindAsync(id);

            if (ordenesDetalle == null)
            {
                return NotFound();
            }

            return ordenesDetalle;
        }

        [HttpGet("byOrder/{id}")]
        public async Task<ActionResult<List<OrdenesDetalle>>> GetbyOrder(int id)
        {
            var ordenesDetalle = await _context.OrdenesDetalles.Where(st=> st.FkIdOrden == id).ToListAsync();

            if (ordenesDetalle == null)
            {
                return NotFound();
            }

            return ordenesDetalle;
        }

        // PUT: api/OrdenesDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesDetalle(int id, OrdenesDetalle ordenesDetalle)
        {
            if (id != ordenesDetalle.PkIdDetalle)
            {
                return BadRequest();
            }

            _context.Entry(ordenesDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesDetalleExists(id))
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

        // POST: api/OrdenesDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesDetalle>> PostOrdenesDetalle(OrdenesDetalle ordenesDetalle)
        {
            _context.OrdenesDetalles.Add(ordenesDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenesDetalle", new { id = ordenesDetalle.PkIdDetalle }, ordenesDetalle);
        }

        // DELETE: api/OrdenesDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenesDetalle(int id)
        {
            var ordenesDetalle = await _context.OrdenesDetalles.FindAsync(id);
            if (ordenesDetalle == null)
            {
                return NotFound();
            }

            _context.OrdenesDetalles.Remove(ordenesDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesDetalleExists(int id)
        {
            return _context.OrdenesDetalles.Any(e => e.PkIdDetalle == id);
        }
    }
}
