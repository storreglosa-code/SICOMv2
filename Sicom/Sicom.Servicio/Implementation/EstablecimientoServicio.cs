using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Implementation
{
    public class EstablecimientoServicio : Servicio<Establecimiento>, IEstablecimientoServicio
    {
        public EstablecimientoServicio(
        IRepositorio<Establecimiento> repositorio,
        IUnitOfWork unitOfWork,
        ILogger<Servicio<Establecimiento>> logger,
        IHttpContextAccessor httpContextAccessor)
        : base(repositorio, unitOfWork, logger, httpContextAccessor)
        {
        }

        public IList<Establecimiento> GetByProvinciaId(ulong provinciaId)
        {
            return GetAllItems(e => e.ProvinciaId == provinciaId).ToList();
        }
    }
}
