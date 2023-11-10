using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb_24AM_2023.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int PkArticulo { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; } 
    }
}
