using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sicom.Dominio.Constants;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.Dominio.Implementation;
using Sicom.Servicio.Contracts;
using Sicom.Servicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Implementation
{
    public class LineaAdministrativaServicio : Servicio<LineaAdministrativa>, ILineaAdministrativaServicio
    {
        private readonly ILogger _logger;
        private readonly IRepositorio<LineaAdministrativa> _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public LineaAdministrativaServicio(
       IRepositorio<LineaAdministrativa> repositorio,
       IUnitOfWork unitOfWork,
       ILogger<Servicio<LineaAdministrativa>> logger,
       IHttpContextAccessor httpContextAccessor)
       : base(repositorio, unitOfWork, logger, httpContextAccessor)
        {
            _logger = logger;
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _contextAccessor = httpContextAccessor;
        }

        public void Crear(LineaAdministrativa nuevaLinea)
        {
            if (_repositorio.GetAll().Any(l => l.NroLinea == nuevaLinea.NroLinea))
            {
                throw new InvalidOperationException("Ya existe una línea con ese número.");
            }

            try
            {
                _repositorio.Add(nuevaLinea);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego un item del tipo Linea Administrativa al repositorio, valores:{nuevaLinea}");
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);

                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{nuevaLinea}");
                throw exception;
            }

        }

        public async Task CrearAsync(LineaAdministrativa nuevaLinea)
        {
            if (_repositorio.GetAll().Any(l => l.NroLinea == nuevaLinea.NroLinea))
            {
                throw new InvalidOperationException("Ya existe una línea con ese número.");
            }

            try
            {
                _repositorio.Add(nuevaLinea);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego un item del tipo Linea Administrativa al repositorio, valores:{nuevaLinea}");
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{nuevaLinea}");
                throw exception;
            }
        }
    }
}
