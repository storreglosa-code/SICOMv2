using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto
{
    public class ModeloCelularDto
    {
        public ulong Id { get; set; }

        public string Descripcion { get; set; }

        public ulong MarcaCelularId { get; set; }
    }
}
