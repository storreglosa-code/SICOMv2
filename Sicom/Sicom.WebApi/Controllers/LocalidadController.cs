using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class LocalidadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<Localidad> _servicio;
        public LocalidadController(IMapper mapper, IServicio<Localidad> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<LocalidadDto>>(_servicio.GetAll()));
        }

        [HttpGet("{provinciaId}")]
        public ActionResult GetByProvinciaId(ulong provinciaId)
        {
            return Ok(_mapper.Map<List<LocalidadDto>>(_servicio.GetAll().Where(l=>l.ProvinciaId == provinciaId)));
        }
    }
}
