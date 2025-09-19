using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class EstadoLineaProfile : Profile
    {
        public EstadoLineaProfile()
        {
            CreateMap<EstadoLinea,EstadoLineaDto>();
        }
    }
}
