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
    public class VideojuegoesController : ControllerBase
    {
        private readonly DataContext _context;

        public VideojuegoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Videojuegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videojuego>>> GetVideojuego()
        {
          if (_context.Videojuego == null)
          {
              return NotFound();
          }
            return await _context.Videojuego.Include(v => v.Desarrolladora).ToListAsync();
        }

        // GET: api/Videojuegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetVideojuego(int id)
        {
          if (_context.Videojuego == null)
          {
              return NotFound();
          }
            var videojuego = _context.Videojuego.
                Include(v => v.Desarrolladora).
                First(v => v.Id_videojuego == id);

            if (videojuego == null)
            {
                return NotFound();
            }

            return videojuego;
        }

        // PUT: api/Videojuegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideojuego(int id, Videojuego videojuego)
        {
            if (id != videojuego.Id_videojuego)
            {
                return BadRequest();
            }

            _context.Entry(videojuego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
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

        // POST: api/Videojuegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videojuego>> PostVideojuego(Videojuego videojuego)
        {
          if (_context.Videojuego == null)
          {
              return Problem("Entity set 'DataContext.Videojuego'  is null.");
          }
            _context.Videojuego.Add(videojuego);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideojuego", new { id = videojuego.Id_videojuego }, videojuego);
        }

        // DELETE: api/Videojuegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideojuego(int id)
        {
            if (_context.Videojuego == null)
            {
                return NotFound();
            }
            var videojuego = await _context.Videojuego.FindAsync(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            _context.Videojuego.Remove(videojuego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideojuegoExists(int id)
        {
            return (_context.Videojuego?.Any(e => e.Id_videojuego == id)).GetValueOrDefault();
        }
    }
}
