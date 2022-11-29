using AdministradorComprasMVC.Data;
using AdministradorComprasMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministradorComprasMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriasController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include:"Nombre,Descripcion")] Categorias categorias)
        {
            //if (!ModelState.IsValid)
            //{
            dbContext.Add<Categorias>(categorias);
            dbContext.SaveChanges();
            //}
            return View();
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var lista = dbContext.Categorias.ToList();
            return View(lista);

        }

        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var categorias = dbContext.Categorias.FirstOrDefault(p => p.Id == id);
            if(categorias==null)
            {
                return NotFound();
            }
            return View(categorias);
        }
    }
}
