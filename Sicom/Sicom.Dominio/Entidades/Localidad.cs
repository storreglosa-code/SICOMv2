using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Localidad : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;
        
        [ForeignKey("Provincia")]
        public ulong ProvinciaId { get; set; }
    }
}
