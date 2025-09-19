using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sicom.Dominio.Constants;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.Servicio.Contracts;
using Sicom.Servicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Servicio.Implementation
{
    public class ObservacionServicio : Servicio<Observacion>, IObservacionServicio
    {
        #region Constructor
        public ObservacionServicio(
        IRepositorio<Observacion> repositorio,
        IUnitOfWork unitOfWork,
        ILogger<Servicio<Observacion>> logger,
        IHttpContextAccessor httpContextAccessor)
        : base(repositorio, unitOfWork, logger, httpContextAccessor)
        {
        }
        #endregion Constructor 

        public IList<Observacion> GetByLineaAdministrativaId(ulong lineaId)
        {
            return GetAllItems(o=>o.LineaAdministrativaId == lineaId).ToList();
        }

        public IList<Observacion> GetByLineaPublicaId(ulong lineaId)
        {
            return GetAllItems(o => o.LineaPublicaId == lineaId).ToList();
        }

        public IList<Observacion> GetByLineaCelularId(ulong lineaId)
        {
            return GetAllItems(o => o.LineaCelularId == lineaId).ToList();
        }

        public void CreateAdministrativa(Observacion observacion) 
        {
            try
            {
                _repositorio.Add(observacion);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego una observacion a Linea Administrativa al repositorio, valores:{observacion}");
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);

                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{observacion}");
                throw exception;
            }
        }

        public void CreatePublica(Observacion observacion)
        {
            try
            {
                _repositorio.Add(observacion);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego una observacion a Linea Publica al repositorio, valores:{observacion}");
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);

                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{observacion}");
                throw exception;
            }
        }

        public void CreateCelular(Observacion observacion)
        {
            try
            {
                _repositorio.Add(observacion);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego una observacion a Linea Celular al repositorio, valores:{observacion}");
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);

                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{observacion}");
                throw exception;
            }
        }
    }
}
