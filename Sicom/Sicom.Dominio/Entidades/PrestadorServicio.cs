using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class PrestadorServicio:Entidad
    {
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;
        
    }
}
