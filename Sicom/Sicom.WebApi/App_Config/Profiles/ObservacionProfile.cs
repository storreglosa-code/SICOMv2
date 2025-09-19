using AutoMapper;
using Sicom.Dominio.Entidades;
using Sicom.WebApi.Dto.Observacion;

namespace Sicom.WebApi.App_Config.Profiles
{
    public class ObservacionProfile : Profile
    {
        public ObservacionProfile()
        {
            //GET
            CreateMap<Observacion,ObservacionAdministrativaDto>();


            //POST
            CreateMap<NuevaObservacionAdministrativaDto, Observacion>();

            CreateMap<NuevaObservacionCelularDto, Observacion>();

            CreateMap<NuevaObservacionPublicaDto, Observacion>();
        }
    }
}
