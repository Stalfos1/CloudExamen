using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpresaVideojuegos.UAPI;
using EmpresaVideojuegos.Modelos;

namespace EmpresaVideojuegos.WebMVC.Controllers
{
    public class DesarrolladorasController : Controller
    {
        private string Url = "https://localhost:7147/api/Desarrolladoras";
        private Crud<Desarrolladora> Crud { get; set; }

        public DesarrolladorasController() 
        {
            Crud =new Crud<Desarrolladora>();

        }

        // GET: DesarrolladorasController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: DesarrolladorasController/Details/5
        public ActionResult Details(int id)
        {
            var datos=Crud.SelectById(Url,id.ToString());
            return View(datos);
        }

        // GET: DesarrolladorasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesarrolladorasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Desarrolladora datos)
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

        // GET: DesarrolladorasController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos= Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: DesarrolladorasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Desarrolladora datos)
        {
            try
            {
                Crud.Update(Url,id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: DesarrolladorasController/Delete/5
        public ActionResult Delete(int id)
        {
             var datos= Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: DesarrolladorasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Desarrolladora datos)
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
