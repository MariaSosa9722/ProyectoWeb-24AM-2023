using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb_24AM_2023.Models.Entities
{
    public class Rol
    {
        [Key]
        public int PkRoles { get; set; }
        [Required]
        public string Nombre { get; set; }  
    }
}
