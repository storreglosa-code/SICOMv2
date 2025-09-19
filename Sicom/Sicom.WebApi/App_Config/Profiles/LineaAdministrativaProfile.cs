using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto.LineaAdministrativa;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class LineaAdministrativaProfile : Profile
    {
        public LineaAdministrativaProfile()
        {
            CreateMap<NuevaLineaAdministrativaDto, LineaAdministrativa>()
                .ForMember(dest => dest.Observaciones, opt => opt.Ignore());
        }
    }
}
