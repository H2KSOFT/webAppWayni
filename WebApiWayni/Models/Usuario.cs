using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading;

namespace WebApiWayni.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

    }
}
