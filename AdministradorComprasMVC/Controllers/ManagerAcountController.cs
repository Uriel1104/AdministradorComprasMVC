using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AdministradorComprasMVC.Data;
using AdministradorComprasMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AdministradorComprasMVC.Controllers
{
    public class ManagerAcountController : Controller
    {
        private readonly ILogger<ManagerAcountController> logger;
        private readonly ApplicationDbContext dbContext;

        public ManagerAcountController(ILogger<ManagerAcountController> _logger, 
            ApplicationDbContext _dbContext)
        {
            
            logger = _logger;
            dbContext = _dbContext;
        }

        [HttpGet(Name ="Create")]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind(include: "Nombre,Descripcion")]Rol rol)
        {
            if(ModelState.IsValid)
            {
                AspNetRoles roles = new AspNetRoles
                {
                    Nombre = rol.Nombre,
                    NombreNormalizado = rol.Nombre.ToUpper()
                };
                dbContext.AspNetRoles.Add(roles);
                dbContext.SaveChanges();
                return View();
                //IdentityRole role = new IdentityRole
                //{
                //    Name = rol.Nombre,
                //    NormalizedName = rol.Nombre.ToUpper()
                //};
                //await _roleManager.CreateAsync(role);
                //return View();
            }
            return View();
        }

        //public JsonResult GetRoles()
        //{
        //    try
        //    {
        //        var roles = new List<Rol>();
        //        var rol = dbContext.Roles.ToList();
        //        if (rol != null)
        //        {
        //            foreach (var r in rol)
        //            {
        //                var role = new Rol();
        //                role.Nombre = r.Name;
        //                role.Descripcion = r.ConcurrencyStamp;
        //                roles.Add(role);

        //            }
        //        }
        //        return Json(roles);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex.Message);
        //        return Json("No se encontraron coincidencias ");
        //    }
        //}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]  
        public async Task<IActionResult> Registro([Bind(include:"Email,Password")]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                AspnetUsers user = new AspnetUsers
                {
                    Email = usuario.Email,
                    Password = usuario.Password,
                    UserName = usuario.Email,
                    
                };

                dbContext.AspNetUsers.Add(user);
                dbContext.SaveChanges();

                var  aspNetUser = dbContext.AspNetUsers
                    .Where(p => p.Email == usuario.Email)
                    .FirstOrDefault();



                AspNetRolesUsers rolesUsers = new AspNetRolesUsers();
                rolesUsers.RoleId = 1;
                rolesUsers.UserId = aspNetUser.Id;
                dbContext.AspNetRolesUsers.Add(rolesUsers);
                dbContext.SaveChanges();
                return View();
            }
            //var user = new IdentityUser { Email = usuario.Email };
            //user.PasswordHash = usuario.Password;

            //var rol = await _roleManager.FindByNameAsync( "Invitado" );

            //if (rol !=null)
            //{
            //    await _userManager.AddToRoleAsync(user, rol.Name);
            //    //Base de datos guardado
            //    await _userManager.CreateAsync(user);
            //}
            
            return View();

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([Bind(include:"Email, Password")] AspnetUsers users)
        {
            //if (ModelState.IsValid)
            //{
            //    var claim = new Claim(ClaimTypes.NameIdentifier, users.Id.ToString());
            //    var claimEmail = new Claim(ClaimTypes.Email, users.Email.ToString());
            //    var claimName = new Claim(ClaimTypes.Name, users.Email.ToString());
            //    dbContext.AspNetUsers.Where(p => p.Email == users.Email && p.Password == users.Password)
            //        .FirstOrDefault();
            //    return RedirectToAction("Index", "Home");

            //}
            //return View();
            if (ModelState.IsValid)
            {
                var user = dbContext.AspNetUsers.Where(p => p.Email == users.Email
                && p.Password == users.Password)
                    .FirstOrDefault();
                if(user != null)
                {
                    HttpContext.Session.SetString("user", user.Email);
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("error", "El usuario y la contraseña son incorrectos");
                return View();
        }
    }
}
