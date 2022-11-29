using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdministradorComprasMVC.Models

{
    [Table("Articulos")]
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [ConcurrencyCheck]
        [Column("Nombre")]

        public string? Nombre { get; set; }

        [Column("Descripcion")]
        public string? Descripcion { get; set; }

        [NotMapped]
        public string? Stock { get; set; }

        [ForeignKey("Categorias")]
        public int CategoriasId { get; set; }
        public Categorias? Caregorias { get; set; }

        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }




    }
}
