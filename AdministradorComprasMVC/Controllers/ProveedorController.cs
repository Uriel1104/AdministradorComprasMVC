using Microsoft.AspNetCore.Mvc;
using AdministradorComprasMVC.Data;
using AdministradorComprasMVC.Models;

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
    }
}
