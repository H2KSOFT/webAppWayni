using System.ComponentModel.DataAnnotations;

namespace WebAppWayni.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        public string Dni { get; set; }
    }
}
