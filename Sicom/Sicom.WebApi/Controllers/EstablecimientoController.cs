using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstablecimientoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<Establecimiento> _servicio;
        private readonly IEstablecimientoServicio _establecimientoServicio;

        public EstablecimientoController(IServicio<Establecimiento> servicio, IMapper mapper, IEstablecimientoServicio establecimientoServicio)
        {
            _mapper = mapper;
            _servicio = servicio;
            _establecimientoServicio = establecimientoServicio;
        }

        [HttpGet]
        public ActionResult GetAll() 
        {
            return Ok(_mapper.Map<List<EstablecimientoDto>>(_servicio.GetAll()));
        }

        [HttpGet("Provincia/{provinciaId}")]
        public ActionResult GetByProvinciaId(ulong provinciaId)
        {
            return Ok(_mapper.Map<List<EstablecimientoDto>>(_establecimientoServicio.GetByProvinciaId(provinciaId)));
        }

    }
}
