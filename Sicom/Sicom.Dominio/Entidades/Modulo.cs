using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Modulo : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [ForeignKey ("Establecimiento")]
        public ulong EstablecimientoId { get; set; }
                
        [Required]
        public virtual ICollection<Pabellon> Pabellones { get; set; } = new List<Pabellon>();
    }
}
