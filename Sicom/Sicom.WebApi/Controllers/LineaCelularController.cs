using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.Servicio.Implementation;

namespace Sicom.WebApi.Controllers
{
    public class LineaCelularController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServicio<LineaCelular> _servicio;

        public LineaCelularController(IMapper mapper, IServicio<LineaCelular> servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<LineaCelular>>(_servicio.GetAll()));
        }
    }
}
