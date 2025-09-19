using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto.Observacion;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.LineaCelular
{
    public class NuevaLineaCelularDto
    {
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}$")]
        [Required]
        public string NroLinea { get; set; }

        [Required]
        [StringLength(22, MinimumLength = 18)]
        [RegularExpression("^[A-Za-z0-9]{18,22}$")]
        public string Sim { get; set; } 

        [Required]
        public ulong EstadoLineaId { get; set; } //Activo - Inactivo

        [Required]
        public ulong EstablecimientoId { get; set; }

        [Required]
        public ulong PrestadorServicioId { get; set; } // MOVISTAR - PERSONAL - ETC

        [Required]
        [StringLength(15, MinimumLength = 15)]
        [RegularExpression("^[0-9]{15}$")]
        public string Imei { get; set; }

        [Required]
        public ulong MarcaId { get; set; }

        [Required]
        public ulong ModeloId { get; set; }

        [Required]
        public ulong AgenteId { get; set; }

        [Required]
        public string? UbicacionFinal { get; set; } //Completa el usuario: Of. de Personal/Judicial/Enfermeria, etc...

        [Required]
        public NuevaObservacionCelularDto ObservacionInicial { get; set; }

    }
}
