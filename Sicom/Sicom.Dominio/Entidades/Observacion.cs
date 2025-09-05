using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Observacion : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public string Texto { get; set; } = string.Empty;

        [ForeignKey("Agente")]
        public ulong AgenteId { get; set; } 
        public virtual Agente? Agente { get; set; }

        [ForeignKey("LineaPublica")]
        public ulong? LineaPublicaId { get; set; }
        public virtual LineaPublica? LineaPublica { get; set; }

        [ForeignKey("LineaAdministrativa")]
        public ulong? LineaAdministrativaId { get; set; }
        public virtual LineaAdministrativa? LineaAdministrativa { get; set; }

        [ForeignKey("LineaCelular")]
        public ulong? LineaCelularId { get; set; }
        public virtual LineaCelular? LineaCelular { get; set; }
    }
}
