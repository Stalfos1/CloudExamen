using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpresaVideojuegos.Modelos;

namespace EmpresaVideojuegos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladorasController : ControllerBase
    {
        private readonly DataContext _context;

        public DesarrolladorasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Desarrolladoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desarrolladora>>> GetDesarrolladora()
        {
          if (_context.Desarrolladora == null)
          {
              return NotFound();
          }
            return await _context.Desarrolladora.
                Include(v=>v.Videojuegos).ToListAsync();
        }

        // GET: api/Desarrolladoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desarrolladora>> GetDesarrolladora(int id)
        {
          if (_context.Desarrolladora == null)
          {
              return NotFound();
          }
            var desarrolladora = _context.Desarrolladora.
                Include(d=>d.Videojuegos).First(d=>d.Id_desarrolladora==id);

            if (desarrolladora == null)
            {
                return NotFound();
            }

            return desarrolladora;
        }

        // PUT: api/Desarrolladoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesarrolladora(int id, Desarrolladora desarrolladora)
        {
            if (id != desarrolladora.Id_desarrolladora)
            {
                return BadRequest();
            }

            _context.Entry(desarrolladora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesarrolladoraExists(id))
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

        // POST: api/Desarrolladoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Desarrolladora>> PostDesarrolladora(Desarrolladora desarrolladora)
        {
          if (_context.Desarrolladora == null)
          {
              return Problem("Entity set 'DataContext.Desarrolladora'  is null.");
          }
            _context.Desarrolladora.Add(desarrolladora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesarrolladora", new { id = desarrolladora.Id_desarrolladora }, desarrolladora);
        }

        // DELETE: api/Desarrolladoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesarrolladora(int id)
        {
            if (_context.Desarrolladora == null)
            {
                return NotFound();
            }
            var desarrolladora = await _context.Desarrolladora.FindAsync(id);
            if (desarrolladora == null)
            {
                return NotFound();
            }

            _context.Desarrolladora.Remove(desarrolladora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesarrolladoraExists(int id)
        {
            return (_context.Desarrolladora?.Any(e => e.Id_desarrolladora == id)).GetValueOrDefault();
        }
    }
}
