using Microsoft.AspNetCore.Mvc;
using AdministradorComprasMVC.Data;
using AdministradorComprasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministradorComprasMVC.Controllers
{
    public class ProveedorController : Controller
    {

        private readonly ILogger<ProveedorController> logger;
        private readonly ApplicationDbContext dbContext;

        public ProveedorController (ILogger<ProveedorController> _logger, ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
            logger = _logger;

        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create([Bind(include: "Rfc,Razon_Social,Nombre_Contacto,Tel_Principal,Tel_Movil,E_mail,Estatus,Fecha_Registro")] Proveedor provedor)
        //{
        //    context.Proveedor.Add(provedor);
        //    context.SaveChanges();
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                dbContext.Proveedor.Add(proveedor);
                dbContext.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Manager()
        {
            var usuario = HttpContext.Session.GetString("user");
            ViewBag.user = usuario;
            if (usuario != null)
            {
                var provedores = dbContext.Proveedor.Include("Direccion")
                .Include("Articulos");//Inner Join
                return View(provedores);
            }
            return RedirectToAction("Login", "ManagerAccount");
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var articulos = dbContext.Articulos.Where(p => p.ProveedorId == id).ToList();
            if (articulos == null)
            {
                return NotFound();
            }
            return View(articulos);
        }

        public async Task<IActionResult> Delete(int? id) //resive el id
        {
            var provedorid = await dbContext.Proveedor.FindAsync(id); // busca el id que resive y se asigna a la varisblr 
            if (id == null)
            {
                return NotFound();
            }
            dbContext.Proveedor.Remove(provedorid); // conexion a la base de datos  y elimino el provedor que tenga el id que se mando 
            dbContext.SaveChanges(); // guardar 
            return RedirectToAction("Manager", "Proveedor"); // vuelve a cargar la pagina 
        }

        public async Task<IActionResult> Editar (int? id)
        {
            var provedorid = await dbContext.Proveedor.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("Manager", "Proveedor");

        }
    }
}
