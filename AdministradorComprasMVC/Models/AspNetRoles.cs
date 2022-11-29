using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorComprasMVC.Models
{
    public class AspNetRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string? NombreNormalizado { get; set; }

        [NotMapped]
        public AspNetRolesUsers? AspNetRolesUsers { get; set; }

    }
}
