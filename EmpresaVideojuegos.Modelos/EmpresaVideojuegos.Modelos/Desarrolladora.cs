using System.ComponentModel.DataAnnotations;

namespace EmpresaVideojuegos.Modelos
{
    public class Desarrolladora
    {
        [Key]
        public int Id_desarrolladora { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public int Año { get; set; }

        //relacion

        public List<Videojuego>? Videojuegos { get; set;}
    }
}