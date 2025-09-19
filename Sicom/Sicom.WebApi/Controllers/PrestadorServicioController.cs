using Microsoft.AspNetCore.Mvc;
using Sicom.Servicio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;
using AutoMapper;

namespace Sicom.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorServicioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<PrestadorServicio> _servicio;

        public PrestadorServicioController(IServicio<PrestadorServicio> servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<PrestadorServicioDto>>(_servicio.GetAll()));
        }
    }
}
