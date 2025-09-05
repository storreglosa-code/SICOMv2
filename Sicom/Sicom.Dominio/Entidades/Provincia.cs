using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Provincia : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public virtual ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
    }
}
