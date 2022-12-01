using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorComprasMVC.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(18)]
        [Column("Rfc")]

        public string Rfc { get; set; }


        [StringLength(80)]
        [Column("Razon_Social")]

        public string Razon_Social { get; set; }


        [StringLength(80)]
        [Column("Nombre_Contacto")]
        public string Nombre_Contacto { get; set; }


        [StringLength(100)]
        [Column("Tel_Principal")]
        public string Tel_Principal { get; set; }


        [StringLength(30)]
        [Column("Tel_Movil")]
        public string Tel_Movil { get; set; }


        [StringLength(80)]
        [Column("E_mail")]
        public string E_mail { get; set; }


        [StringLength(15)]
        [Column("Estatus")]
        public string Estatus { get; set; }

        [Column("Fecha_Registro")]
        public DateTime Fecha_Registro { get; set; }

        //Composición: llevarse todo d eun solo tajo
        public DireccionProveedor? Direccion { get; set; }

        public List<Articulo>? Articulos { get; set; }
    }
}
