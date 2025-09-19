using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class TipoEquipoTelefonicoProfile : Profile
    {
        public TipoEquipoTelefonicoProfile()
        {
            CreateMap<TipoEquipoTelefonico, TipoEquipoTelefonicoDto>();
        }
    }
}
