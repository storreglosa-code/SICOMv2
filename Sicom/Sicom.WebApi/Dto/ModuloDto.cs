using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto
{
    public class ModuloDto
    {
        public ulong Id { get; set; }

        public string Nombre { get; set; } 

        public ulong EstablecimientoId { get; set; }
    }
}
