using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class LineaAdministrativa : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}$")]
        public string NroLinea { get; set; } = string.Empty;
        public string? NroInterno { get; set; } = string.Empty;

        [Required]
        public ulong EstadoLineaId { get; set; } //Activo - Inactivo
        public virtual EstadoLinea? EstadoLinea { get; set; }

        [Required]
        public ulong EstablecimientoId { get; set; }
        public virtual Establecimiento? Establecimiento { get; set; }

        [Required]
        public ulong ModuloId { get; set; }
        public virtual Modulo? Modulo { get; set; }

        [Required]
        public ulong PabellonId { get; set; }
        public virtual Pabellon? Pabellon { get; set; }

        [Required]
        public ulong ModalidadId { get; set; }
        public virtual ModalidadLinea? Modalidad { get; set; } // ENTRANTE - SALIENTE - BIDIRECCIONAL 

        public string? UbicacionFinal { get; set; } //Completa el usuario: Of. de Personal/Judicial/Enfermeria, etc...

        [Required]
        public ulong PrestadorServicioId { get; set; } // MOVISTAR - PERSONAL - ETC
        public virtual PrestadorServicio? PrestadorServicio { get; set; }

        [Required]
        public ulong OrigenServicioId { get; set; }
        public virtual OrigenServicio? OrigenServicio { get; set; } //COBRE, GSM, IP

        public bool Eliminado { get; set; } = false;
        public string? MotivoBaja { get; set; } = string.Empty;
        public virtual ICollection<Observacion> Observaciones { get; set; } = new List<Observacion>();
        
    }

}
