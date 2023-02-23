using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorComprasMVC.Models
{
    public class Categorias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [ConcurrencyCheck]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        [StringLength(250)]
        public string Descripcion { get; set; }

        public List<Articulo> Articulos { get; set; }
    }
}
