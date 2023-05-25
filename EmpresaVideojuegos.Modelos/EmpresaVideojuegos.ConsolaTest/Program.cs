using EmpresaVideojuegos.UAPI;
using EmpresaVideojuegos.Modelos;

var uapi = new Crud<Desarrolladora>();

var desarrolladoras= uapi.Select("https://localhost:7147/api/Desarrolladoras");
var ec = uapi.SelectById("https://localhost:7147/api/Desarrolladoras", "1");

Console.WriteLine("Hello, World!");
