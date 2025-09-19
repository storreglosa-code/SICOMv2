using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.Observacion
{
    public class NuevaObservacionAdministrativaDto
    {
        [Required]
        public ulong LineaAdministrativaId { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public ulong AgenteId { get; set; }
    }
}
