using System.ComponentModel.DataAnnotations;

namespace Sicom.WebApi.Dto
{
    public class MarcaCelularDto
    {
        public ulong Id { get; set; }

        public string Descripcion { get; set; } 
    }
}
