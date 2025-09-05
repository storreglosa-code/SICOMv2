using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Entidades
{
    public class ModeloCelular : Entidad
    {
        [Key]
        public new ulong Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [ForeignKey("MarcaCelular")]
        public ulong MarcaCelularId { get; set; }
        public virtual MarcaCelular Marca { get; set; }

    }
}
