using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto
{
    public class LocalidadDto
    {
        public ulong Id { get; set; }

        public string Nombre { get; set; }

        public ulong ProvinciaId { get; set; }
    }
}
