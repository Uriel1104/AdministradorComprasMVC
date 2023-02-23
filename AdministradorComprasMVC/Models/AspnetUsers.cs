using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorComprasMVC.Models
{
    public class AspnetUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]

        public string? UserName { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Password { get; set; }
        
        public string? Telefono { get; set; }
        [NotMapped]
        
        public AspNetRolesUsers? AspNetRolesUser { get; set; }
    }
}
