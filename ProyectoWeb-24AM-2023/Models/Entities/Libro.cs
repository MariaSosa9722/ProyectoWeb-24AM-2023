using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb_24AM_2023.Models.Entities
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; }
        [Required]
        public string Images { get; set; }

        [Required]
        public string Activo { get; set; }

    }
}
