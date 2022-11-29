using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorComprasMVC.Models
{
    public class DireccionProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        [StringLength(150)]
        [ConcurrencyCheck]
        public string? calle { get; set; }
        public string? NoInt { get; set; }
        public string? NoExt { get; set; }
        public string? Colonia { get; set; }
        public string? Localidad { get; set; }
        public string? Entidad { get; set; }
        public string? Municipio { get; set; }
        public string? Pais { get; set; }
        public string? CodigoPostal { get; set; }

        [ForeignKey("ProveedorId")]
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

    }
}
