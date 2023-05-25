using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVideojuegos.Modelos
{
    public class Videojuego
    {
        [Key]
        public int Id_videojuego { get; set; }
        public string? Nombre { get; set; }
        public int Año { get; set; }
        public string? GeneroPrincipal { get; set; }
        public double Precio { get; set; }

        //relacion 
        public Desarrolladora? Desarrolladora { get; set; }
    }
}
