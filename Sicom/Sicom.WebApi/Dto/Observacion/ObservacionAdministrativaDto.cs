using Sicom.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.Observacion
{
    public class ObservacionAdministrativaDto
    {
        public ulong? LineaAdministrativaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Texto { get; set; } 

        public string AgenteNombre { get; set; }

        public string AgenteApellido { get; set; }

        public string AgenteCredencial { get; set; }

        public string AgenteGrado { get; set; }
    }
}
