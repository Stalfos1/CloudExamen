using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpresaVideojuegos.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<EmpresaVideojuegos.Modelos.Desarrolladora> Desarrolladora { get; set; } = default!;

        public DbSet<EmpresaVideojuegos.Modelos.Videojuego>? Videojuego { get; set; }
    }
