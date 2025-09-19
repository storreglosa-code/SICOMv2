using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class Establecimiento : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        public ulong TadId { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Alias { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ProvinciaId")]
        public ulong ProvinciaId { get; set; } 

        [Required]
        [ForeignKey("LocalidadId")]
        public ulong LocalidadId { get; set; } 
                
        [Required]
        public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    }
}
