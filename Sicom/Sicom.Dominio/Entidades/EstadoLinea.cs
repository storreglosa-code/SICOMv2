using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class EstadoLinea : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;
    }
}
