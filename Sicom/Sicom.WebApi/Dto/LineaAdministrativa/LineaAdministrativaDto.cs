using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto.Observacion;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.LineaAdministrativa
{
    public class LineaAdministrativaDto
    {
        public ulong Id { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}$")]
        public string NroLinea { get; set; } 

        [StringLength(6)]
        [RegularExpression("^[0-9]{10}$")]
        public string? NroInterno { get; set; } 

        public string EstadoLineaDescripcion { get; set; } //Activo - Inactivo

        public string EstablecimientoDescripcion { get; set; }

        public string ModuloDescripcion { get; set; }

        public string PabellonDescripcion { get; set; }

        public string ModalidadDescripcion { get; set; } // ENTRANTE - SALIENTE - BIDIRECCIONAL 

        public string? UbicacionFinal { get; set; } //Completa el usuario: Of. de Personal/Judicial/Enfermeria, etc...

        public string PrestadorServicioDescripcion { get; set; } // MOVISTAR - PERSONAL - ETC

        public string OrigenServicioDescripcion { get; set; } //COBRE, GSM, IP

        public bool Eliminado { get; set; } 

        public string? MotivoBaja { get; set; } 

        public virtual ICollection<ObservacionAdministrativaDto> Observaciones { get; set; } = new List<ObservacionAdministrativaDto>();
    }
}
