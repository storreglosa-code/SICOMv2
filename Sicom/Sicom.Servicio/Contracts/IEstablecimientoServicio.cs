using Sicom.Dominio.Entidades;
using Sicom.Servicio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Contracts
{
    public interface IEstablecimientoServicio : IServicio<Establecimiento>
    {
        IList<Establecimiento> GetByProvinciaId (ulong provinciaId);
    }
}
