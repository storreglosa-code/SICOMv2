using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrigenServicioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<OrigenServicio> _servicio;

        public OrigenServicioController(IMapper mapper, IServicio<OrigenServicio> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<OrigenServicioDto>>(_servicio.GetAll()));
        }
    }
}
