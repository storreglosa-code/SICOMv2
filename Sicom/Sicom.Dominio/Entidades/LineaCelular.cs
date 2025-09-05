using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class LineaCelular : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}$")]
        public string Numero { get; set; } = string.Empty;

        [Required]
        [StringLength(22, MinimumLength = 18)]
        [RegularExpression("^[A-Za-z0-9]{18,22}$")]
        public string Sim { get; set; } = string.Empty;

        [Required]
        public ulong EstadoLineaId { get; set; } //Activo - Inactivo
        public virtual EstadoLinea? EstadoLinea { get; set; }

        [Required]
        public ulong EstablecimientoId { get; set; }
        public virtual Establecimiento? Establecimiento { get; set; }

        [Required]
        public ulong PrestadorServicioId { get; set; } // MOVISTAR - PERSONAL - ETC
        public virtual PrestadorServicio? PrestadorServicio { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15)]
        [RegularExpression("^[0-9]{15}$")]
        public string Imei { get; set; } = string.Empty;

        [Required]
        public ulong MarcaId { get; set; } 
        public virtual MarcaCelular? Marca { get; set; }

        [Required]
        public ulong ModeloId { get; set; }
        public virtual ModeloCelular? Modelo { get; set; }

        [Required]
        public ulong AgenteId { get; set; } 
        public virtual Agente? Agente { get; set; }

        public string UbicacionFinal { get; set; }
        public string? PlanContratado {  get; set; } = string.Empty; //solo completado por ADMINS
        public bool Eliminado { get; set; } = false;

        public string MotivoBaja { get; set; } = string.Empty;

        public virtual ICollection<Observacion> Observaciones { get; set; } = new List<Observacion>();
    }
}
