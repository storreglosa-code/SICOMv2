using System.ComponentModel.DataAnnotations;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class MarcaCelular : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<ModeloCelular> Modelos { get; set; } = new List<ModeloCelular>();
    }
}
