using Sicom.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Contracts
{
    public interface IObservacionServicio
    {
        IList<Observacion> GetByLineaAdministrativaId(ulong lineaId);

        IList<Observacion> GetByLineaPublicaId(ulong lineaId);

        IList<Observacion> GetByLineaCelularId(ulong lineaId);

        void CreateAdministrativa(Observacion observacion);

        void CreatePublica(Observacion observacion);

        void CreateCelular(Observacion observacion);

    }
}
