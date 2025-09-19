namespace Sicom.WebApi.Dto
{
    public class EstablecimientoDto
    {
        public ulong Id { get; set; }

        public string Nombre { get; set; }

        public string Alias { get; set; }

        public ulong ProvinciaId { get; set; }

        public ulong LocalidadId { get; set; }
    }
}
