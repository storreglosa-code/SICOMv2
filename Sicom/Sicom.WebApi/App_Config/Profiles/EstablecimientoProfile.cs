using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class EstablecimientoProfile : Profile
    {
        public EstablecimientoProfile()
        {
            CreateMap<Establecimiento, EstablecimientoDto>();
        }
    }
}
