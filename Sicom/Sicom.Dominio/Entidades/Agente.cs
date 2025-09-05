using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Agente : Entidad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Credencial { get; set; } = string.Empty;

        [Required]
        public string Grado { get; set; } = string.Empty;

        [Required]
        public string Funcion { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public ulong EstablecimientoId { get; set; }

        public virtual ICollection<LineaCelular> LineasCelulares { get; set; } = new List<LineaCelular>();


    }
}
