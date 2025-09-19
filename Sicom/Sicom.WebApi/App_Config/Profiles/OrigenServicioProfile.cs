using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class OrigenServicioProfile : Profile
    {
        public OrigenServicioProfile()
        {
            CreateMap<OrigenServicio, OrigenServicioDto>();
        }
    }
}
