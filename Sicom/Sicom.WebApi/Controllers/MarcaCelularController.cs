using Microsoft.AspNetCore.Mvc;
using Sicom.Servicio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;
using AutoMapper;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaCelularController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<MarcaCelular> _servicio;

        public MarcaCelularController(IMapper mapper, IServicio<MarcaCelular> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<MarcaCelularDto>>(_servicio.GetAll()));
        }
    }
}
