using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoEquipoTelefonicoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<TipoEquipoTelefonico> _servicio;

        public TipoEquipoTelefonicoController(IMapper mapper, IServicio<TipoEquipoTelefonico> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<TipoEquipoTelefonicoDto>>(_servicio.GetAll()));
        }
    }
}
