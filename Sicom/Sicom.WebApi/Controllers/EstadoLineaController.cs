using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoLineaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<EstadoLinea> _servicio;

        public EstadoLineaController(IMapper mapper, IServicio<EstadoLinea> servicio)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<EstadoLineaDto>>(_servicio.GetAll()));
        }
    }
}
