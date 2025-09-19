using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto.Observacion;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservacionController : Controller
    {
        private readonly IServicio<Observacion> _servicio;
        private readonly IObservacionServicio _observacionServicio;
        private readonly IMapper _mapper;

        public ObservacionController(IMapper mapper, IServicio<Observacion> servicio, IObservacionServicio observacionServicio)
        {
            _mapper = mapper;
            _servicio = servicio;
            _observacionServicio = observacionServicio;
        }


        [HttpGet("Administrativa/{lineaId}")]
        public ActionResult GetByLineaAdministrativaId(ulong lineaId)
        {
            var observaciones = _observacionServicio.GetByLineaAdministrativaId(lineaId);
            return Ok(_mapper.Map<List<ObservacionAdministrativaDto>>(observaciones));
        }

        
        [HttpGet("Celular/{lineaId}")]
        public ActionResult GetByLineaCelularId(ulong lineaId)
        {
            var observaciones = _observacionServicio.GetByLineaCelularId(lineaId);
            return Ok(_mapper.Map<List<ObservacionCelularDto>>(observaciones));
        }

        [HttpGet("Publica/{lineaId}")]
        public ActionResult GetByLineaPublicaId(ulong lineaId)
        {
            var observaciones = _observacionServicio.GetByLineaPublicaId(lineaId);
            return Ok(_mapper.Map<List<ObservacionPublicaDto>>(observaciones));
        }

        [HttpPost("Administrativa")]
        public ActionResult CreateAdministrativa (NuevaObservacionAdministrativaDto dto)
        {
            var observacion = _mapper.Map<Observacion>(dto);
            _observacionServicio.CreateAdministrativa(observacion);
            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)] //FALTA el CRUD de la LINEA CELULAR
        [HttpPost("Celular")]
        public ActionResult CreateCelular (NuevaObservacionCelularDto dto)
        {
            var observacion = _mapper.Map<Observacion>(dto);
            _observacionServicio.CreateCelular(observacion);
            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)] //FALTA el CRUD de la LINEA PUBLICA
        [HttpPost("Publica")]
        public ActionResult CreatePublica(NuevaObservacionPublicaDto dto)
        {
            var observacion = _mapper.Map<Observacion>(dto);
            _observacionServicio.CreatePublica(observacion);
            return Ok();
        }
    }
}
