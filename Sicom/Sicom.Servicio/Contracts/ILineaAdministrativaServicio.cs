using Sicom.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Contracts
{
    public interface ILineaAdministrativaServicio
    {
        void Crear(LineaAdministrativa lineaAdministrativa);

        Task CrearAsync(LineaAdministrativa lineaAdministrativa);
    }
}
