using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto.Observacion
{
    public class NuevaObservacionPublicaDto
    {
        [Required]
        public ulong LineaPublicaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public ulong AgenteId { get; set; }
    }
}
