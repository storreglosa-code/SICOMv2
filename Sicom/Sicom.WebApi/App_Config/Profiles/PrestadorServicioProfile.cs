using AutoMapper;
using Sicom.WebApi.Dto;
using Sicom.Dominio.Entidades;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class PrestadorServicioProfile : Profile
    {
        public PrestadorServicioProfile()
        {
            CreateMap<PrestadorServicio,PrestadorServicioDto>();
        }
    }
}
