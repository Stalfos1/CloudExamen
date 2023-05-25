using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpresaVideojuegos.UAPI;
using EmpresaVideojuegos.Modelos;

namespace EmpresaVideojuegos.WebMVC.Controllers
{
    public class VideojuegosController : Controller
    {

        private string Url = "https://localhost:7147/api/Videojuegoes";
        private Crud<Videojuego> Crud { get; set; }

        public VideojuegosController()
        {
            Crud = new Crud<Videojuego>();

        }

        // GET: VideojuegosController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: VideojuegosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // GET: VideojuegosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideojuegosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Videojuego datos)
        {
            try
            {
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: VideojuegosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: VideojuegosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Videojuego datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: VideojuegosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: VideojuegosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Videojuego datos)
        {
            try
            {
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
