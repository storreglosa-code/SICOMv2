using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto.LineaAdministrativa;
using Sicom.WebApi.Dto.Observacion;
using System.Transactions;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineaAdministrativaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<LineaAdministrativa> _servicio;
        private readonly IObservacionServicio _observacionServicio;
        private readonly ILineaAdministrativaServicio _lineaAdministrativaServicio;

        public LineaAdministrativaController(
            IMapper mapper, 
            IServicio<LineaAdministrativa> servicio, 
            IObservacionServicio observacionServicio, 
            ILineaAdministrativaServicio lineaAdministrativaServicio)
        {
            _mapper = mapper;
            _servicio = servicio;
            _observacionServicio = observacionServicio;
            _lineaAdministrativaServicio = lineaAdministrativaServicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var query = _servicio.GetAll();
            var lineasAdministrativas = new List<LineaAdministrativaDto>();
            foreach (var item in query)
            {
                var dto = new LineaAdministrativaDto()
                {
                    Id = item.Id,
                    NroLinea = item.NroLinea,
                    NroInterno = item.NroInterno,
                    EstadoLineaDescripcion = item.EstadoLinea.Descripcion,
                    ModuloDescripcion = item.Modulo.Nombre,
                    PabellonDescripcion = item.Pabellon.Nombre,
                    ModalidadDescripcion = item.Modalidad.Descripcion,
                    UbicacionFinal = item.UbicacionFinal,
                    PrestadorServicioDescripcion = item.PrestadorServicio.Descripcion,
                    OrigenServicioDescripcion = item.OrigenServicio.Descripcion,
                };
                foreach (var ob in item.Observaciones)
                {
                    var observacionDto = new ObservacionAdministrativaDto()
                    {
                        LineaAdministrativaId = ob.LineaAdministrativaId,
                        AgenteApellido = ob.Agente.Apellido,
                        AgenteCredencial = ob.Agente.Credencial,
                        AgenteGrado = ob.Agente.Grado,
                        AgenteNombre = ob.Agente.Nombre,
                        Texto = ob.Texto,
                        Fecha = ob.Fecha
                    };
                    dto.Observaciones.Add(observacionDto);
                }

                lineasAdministrativas.Add(dto);
            }

            return Ok(lineasAdministrativas);
        }

        [HttpPost]
        public ActionResult Create([FromBody] NuevaLineaAdministrativaDto dto)
        { 
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var nuevaLinea = _mapper.Map<LineaAdministrativa>(dto);
            try
            {
                _lineaAdministrativaServicio.Crear(nuevaLinea);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (dto.ObservacionInicial != null && !string.IsNullOrWhiteSpace(dto.ObservacionInicial.Texto))
            {
                var nuevaObservacion = _mapper.Map<Observacion>(dto.ObservacionInicial);
                nuevaObservacion.LineaAdministrativaId = nuevaLinea.Id;
     
                _observacionServicio.CreateAdministrativa(nuevaObservacion);
            }
                        
            return Ok("Linea creada exitosamente");
        }
    }
}
