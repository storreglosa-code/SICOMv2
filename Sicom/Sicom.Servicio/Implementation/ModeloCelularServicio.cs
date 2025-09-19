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
    public class ModeloCelularServicio : Servicio<ModeloCelular>, IModeloCelularServicio
    {
        public ModeloCelularServicio(
        IRepositorio<ModeloCelular> repositorio,
        IUnitOfWork unitOfWork,
        ILogger<Servicio<ModeloCelular>> logger,
        IHttpContextAccessor httpContextAccessor)
        : base(repositorio, unitOfWork, logger, httpContextAccessor)
        {
        }

        public IList<ModeloCelular> GetByMarcaCelularId(ulong marcaCelularId)
        {
            return GetAllItems(mc=>mc.MarcaCelularId == marcaCelularId).ToList();
        }
    }
}
