using System.ComponentModel.DataAnnotations;

namespace AdministradorComprasMVC.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo de rol es requerido")]
        [StringLength(150)]

        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
