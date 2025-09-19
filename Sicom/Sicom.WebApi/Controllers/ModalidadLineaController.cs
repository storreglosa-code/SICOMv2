using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.Controllers
{
    public class ModalidadLineaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicio<ModalidadLinea> _servicio;

        public ModalidadLineaController(IMapper mapper, IServicio<ModalidadLinea> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<ModalidadLineaDto>>(_servicio.GetAll()));
        }
    }
}
