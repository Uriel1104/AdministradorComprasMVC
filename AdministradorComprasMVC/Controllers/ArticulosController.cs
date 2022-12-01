using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdministradorComprasMVC.Models;
using AdministradorComprasMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministradorComprasMVC.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext context;

        public ArticulosController(ApplicationDbContext _context) 
        {
            context = _context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(context.Categorias.ToList(), "Id", "Nombre");
            ViewBag.Proveedores = new SelectList(context.Proveedor.ToList(), "Id", "Razon_Social");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken] /*No permite pasar los tokens desde una peticion http*/
        public IActionResult Create([Bind(include: "Nombre, Descripcion, Stock, CategoriasId, ProveedorId")]Articulo articulo)
        {
            ViewBag.Categorias = new SelectList(context.Categorias.ToList(), "Id", "Nombre");
            ViewBag.Proveedores = new SelectList(context.Proveedor.ToList(), "Id", "Razon_Social");
            context.Articulos.Add(articulo);
            context.SaveChanges();
            return View();
        }
    }
}
