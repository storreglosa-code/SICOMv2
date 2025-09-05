using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Pabellon : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Modulo es obligatorio")]
        public ulong ModuloId { get; set; }

        [Required(ErrorMessage = "El Establecimiento es obligatorio")]
        public ulong EstablecimientoId { get; set; }
        
        public ushort? PoblacionPenal { get; set; }

    }
}
