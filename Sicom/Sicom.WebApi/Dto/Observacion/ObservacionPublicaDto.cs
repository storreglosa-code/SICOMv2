namespace Sicom.WebApi.Dto.Observacion
{
    public class ObservacionPublicaDto
    {
        public ulong LineaPublicaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Texto { get; set; }

        public string AgenteNombre { get; set; }

        public string AgenteApellido { get; set; }

        public string AgenteCredencial { get; set; }

        public string AgenteGrado { get; set; }
    }
}
