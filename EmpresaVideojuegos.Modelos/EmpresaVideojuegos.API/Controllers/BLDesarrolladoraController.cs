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
    public class BLDesarrolladoraController : ControllerBase
    {
        private readonly DataContext _context;

        public BLDesarrolladoraController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DALDesarrolladora
        [Route("/BL/PrecioTotal")]
        [HttpGet]
        public  ActionResult<double> PrecioTotal()
        {
          if (_context.Desarrolladora == null)
          {
              return NotFound();
          }
            return _context.Videojuego.Sum(v=>v.Precio);
        }
    }
}
