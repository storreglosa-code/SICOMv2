using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<Provincia> _servicio;

        public ProvinciaController(IMapper mapper, IServicio<Provincia> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<ProvinciaDto>>(_servicio.GetAll()));
        }
    }
}
