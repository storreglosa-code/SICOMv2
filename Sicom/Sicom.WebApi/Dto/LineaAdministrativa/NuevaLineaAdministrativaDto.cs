using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto.Observacion;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.LineaAdministrativa
{
    public class NuevaLineaAdministrativaDto ()
    {
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}$")]
        [Required]
        public string NroLinea { get; set; }

        [StringLength(6)]
        [RegularExpression("^[0-9]+$")]
        [Required]
        public string? NroInterno { get; set; }

        [Required]
        public string? UbicacionFinal { get; set; } //Completa el usuario: Of. de Personal/Judicial/Enfermeria, etc...

        [Required]
        public NuevaObservacionAdministrativaDto ObservacionInicial { get; set; }

        [Required]
        public ulong EstadoLineaId { get; set; } //Activo - Inactivo

        [Required]
        public ulong EstablecimientoId { get; set; }

        [Required]
        public ulong ModalidadId { get; set; } // ENTRANTE - SALIENTE - BIDIRECCIONAL 

        [Required]
        public ulong PrestadorServicioId { get; set; } // MOVISTAR - PERSONAL - ETC

        [Required]
        public ulong OrigenServicioId { get; set; } //COBRE, GSM, IP

        public ulong ModuloId { get; set; }

        public ulong PabellonId { get; set; }

    }
}
