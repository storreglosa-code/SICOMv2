using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloCelularController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<ModeloCelular> _servicio;
        private readonly IModeloCelularServicio _modeloCelularServicio;

        public ModeloCelularController(IMapper mapper, IServicio<ModeloCelular> servicio, IModeloCelularServicio modeloCelularServicio)
        {
            _mapper = mapper;
            _servicio = servicio;
            _modeloCelularServicio = modeloCelularServicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<ModeloCelularDto>>(_servicio.GetAll()));
        }

        [HttpGet("Marca/{marcaCelularId}")]
        public ActionResult GetByMarcaId(ulong marcaCelularId)
        {
            return Ok(_mapper.Map<List<ModeloCelularDto>>(_modeloCelularServicio.GetByMarcaCelularId(marcaCelularId)));
        }

    }
}
