using System.Linq.Expressions;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sicom.Dominio.Constants;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.Dominio.Extensions;
using Sicom.Servicio.Contracts;
using Sicom.Servicio.Exceptions;


namespace Sicom.Servicio.Implementation
{
    public class Servicio<T> : IServicio<T> where T : Entidad
    {
        #region Propiedades
        protected readonly IRepositorio<T> _repositorio;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<Servicio<T>> _logger;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly Guid _instanceGuid;
        private readonly string _tipo;
        private readonly JsonSerializerSettings _jsonOptions;
        #endregion Propiedades

        #region Constructor
        public Servicio(IRepositorio<T> repositorio, IUnitOfWork unitOfWork, ILogger<Servicio<T>> logger, IHttpContextAccessor httpContextAccessor)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _instanceGuid = Guid.NewGuid();
            _tipo = typeof(T).ToString();
            _jsonOptions = new JsonSerializerSettings();
            _jsonOptions.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
        #endregion Constructor

        #region Metodos Publicos

        public T Get(ulong id)
        {
            _logger.LogInformation(LogEvents.Service,
                $"Buscando entidad del tipo {_tipo} con id:{id}.");

            var entity = _repositorio.Get(id);


            var entidad = JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, _jsonOptions);

            _logger.LogInformation(LogEvents.Service, "Entidad obtenida: {entidad}.", entidad);

            return entity;
        }

        public async Task<T> GetAsync(ulong id)
        {
            _logger.LogInformation(LogEvents.Service, $"Buscando entidad del tipo {_tipo} con id:{id}.");

            var entity = await _repositorio.GetAsync(id);

            var entidad = JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, _jsonOptions);

            _logger.LogInformation(LogEvents.Service, $"Entidad obtenida: {entidad}.");

            return entity;
        }

        protected T Get(Expression<Func<T, bool>> predicate)
        {
            _logger.LogInformation(LogEvents.Service, $"Buscando entidad del tipo {_tipo} con predicado:{predicate}.");

            var entity = GetAllItems().SingleOrDefault(predicate);

            var entidad = JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, _jsonOptions);

            _logger.LogInformation(LogEvents.Service,
                "Entidad obtenida: {entidad}.", entidad);

            return entity;
        }

        protected async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            _logger.LogInformation(LogEvents.Service,
                "Buscando entidad del tipo {_tipo} con predicado:{predicate}.", _tipo, predicate);

            var entity = await GetAllItems().SingleOrDefaultAsync(predicate);

            var entidad = JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, _jsonOptions);

            _logger.LogInformation(LogEvents.Service,
                "Entidad obtenida: {entidad}.", entidad);

            return entity;
        }

        protected IQueryable<T> GetAllItems()
        {
            return GetAllItems(null);
        }

        protected IQueryable<T> GetAllItems(Expression<Func<T, bool>> predicate)
        {
            var query = _repositorio.GetAll();

            if (predicate != null)
            {
                _logger.LogInformation(LogEvents.Service, $"Buscando entidades del tipo {_tipo} con predicado:{predicate}.");
                return query.Where(predicate);
            }

            _logger.LogInformation(LogEvents.Service, $"Buscando entidades del tipo {_tipo} sin ningun tipo de predicado. Si la lista supera los 10.000 resultados se emitira una advertencia");

            return query;
        }

        public IList<T> GetAll()
        {
            _logger.LogInformation(LogEvents.Service,
                $"Buscando entidades del tipo {_tipo} sin ningun tipo de predicado. Si la lista supera los 10.000 resultados se emitira una advertencia");
            var items = GetAllItems().ToList();

            if (items.Count > 10000)
                _logger.LogInformation(LogEvents.Service, $"Se buscaron mas de 10.000 entidades del tipo {_tipo} sin ningun tipo de predicado.");

            return items;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            _logger.LogInformation(LogEvents.Service, 
                @$"Buscando entidades del tipo {_tipo} sin ningun tipo de predicado. 
                Si la lista supera los 10.000 resultados se emitira una advertencia");

            var items = await GetAllItems().ToListAsync();

            if (items.Count > 10000)
                _logger.LogInformation(LogEvents.Service, 
                    $"Se buscaron mas de 10.000 entidades del tipo {_tipo} sin ningun tipo de predicado.");

            return items;
        }

        public IList<T> GetAllOrderedBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _logger.LogInformation(LogEvents.Service,
                @$"Buscando entidades del tipo {_tipo} sin ningun tipo de predicado y ordenadas por:{keySelector}.
                Si la lista supera los 10.000 resultados se emitira una advertencia");
            var items = GetAllItems().OrderBy(keySelector).ToList();

            if (items.Count > 10000)
                _logger.LogInformation(LogEvents.Service,
                    $"Se buscaron mas de 10.000 entidades del tipo {_tipo} sin ningun tipo de predicado y ordenadas por:{keySelector}.");

            return items;
        }

        public async Task<IList<T>> GetAllOrderedByAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _logger.LogInformation(LogEvents.Service,
                @$"Buscando entidades del tipo {_tipo} sin ningun tipo de predicado y ordenadas por:{keySelector}. 
                Si la lista supera los 10.000 resultados se emitira una advertencia");
            var items = await GetAllItems().OrderBy(keySelector).ToListAsync();

            if (items.Count > 10000)
                _logger.LogInformation(LogEvents.Service,
                    $"Se buscaron mas de 10.000 entidades del tipo {_tipo} sin ningun tipo de predicado y ordenadas por:{keySelector}.");

            return items;
        }

        public virtual Page<T> GetAll<TKey>(int page, int pageSize, Expression<Func<T, TKey>> orderBy,
            bool ascending = true)
        {
            return GetPage(page, pageSize, orderBy, ascending);
        }

        public virtual Page<T> GetAll<TKey, TSec>(int page, int pageSize, Expression<Func<T, TKey>> orderBy,
            Expression<Func<T, TSec>> thenBy, bool ascending = true)
        {
            return GetPage(page, pageSize, orderBy, thenBy, ascending);
        }

        public virtual void Create(T item)
        {
            try
            {
                _repositorio.Add(item);
                _logger.LogInformation(LogEvents.Service,
                    "Se agrego un item del tipo {_tipo} al repositorio, valores:{item}", _tipo, item);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);

                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{item}");
                throw exception;
            }
        }

        public virtual async Task CreateAsync(T item)
        {
            try
            {
                _repositorio.Add(item);
                _logger.LogInformation(LogEvents.Service,
                    $"Se agrego un item del tipo {_tipo} al repositorio, valores:{item}");
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al crear el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error creando el item:{item}");
                throw exception;
            }
        }

        public virtual void Update(T item)
        {
            try
            {
                _logger.LogInformation(LogEvents.Service,
                    $"Se solicito actualizar un item del tipo {_tipo}, valores:{item}");
                _repositorio.Update(item);
                _logger.LogInformation(LogEvents.Service,
                    $"Se actualizo un item del tipo {_tipo} en el repositorio, valores:{item}");
                _unitOfWork.SaveChanges();
                _logger.LogInformation(LogEvents.Service, $"Item actualizado del tipo {_tipo}, valores:{item}");
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al editar el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error actualizando el item:{item}");
                throw exception;
            }

        }

        public virtual async Task UpdateAsync(T item)
        {
            try
            {
                _logger.LogInformation(LogEvents.Service,
                    $"Se solicito actualizar un item del tipo {_tipo}, valores:{item}");
                _repositorio.Update(item);
                _logger.LogInformation(LogEvents.Service,
                    $"Se actualizo un item del tipo {_tipo} en el repositorio, valores:{item}");
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation(LogEvents.Service, $"Item actualizado del tipo {_tipo}, valores:{item}");
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al editar el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error actualizando el item:{item}");
                throw exception;
            }
        }

        public virtual void Delete(ulong id)
        {
            try
            {
                var item = _repositorio.Get(id);
                _logger.LogInformation(LogEvents.Service,
                    $"Se solicito eliminar un item del tipo {_tipo}, valores:{item}");
                _repositorio.Delete(item);
                _logger.LogInformation(LogEvents.Service,
                    $"Se elimino un item del tipo {_tipo} en el repositorio, valores:{item}");
                _unitOfWork.SaveChanges();
                _logger.LogInformation(LogEvents.Service, $"Item eliminado del tipo {_tipo}, valores:{item}");
            }
            catch (Exception ex)
            { 
                var exception = new ServiceException("Ocurrio un error al eliminar el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error elimando el item con id:{id}");
                throw exception;
            }
        }

        public virtual async Task DeleteAsync(ulong id)
        {
            try
            {
                var item = await _repositorio.GetAsync(id);
                _logger.LogInformation(LogEvents.Service,
                    $"Se solicito eliminar un item del tipo {_tipo}, valores:{item}");
                _repositorio.Delete(item);
                _logger.LogInformation(LogEvents.Service,
                    $"Se elimino un item del tipo {_tipo} en el repositorio, valores:{item}");
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation(LogEvents.Service, $"Item eliminado del tipo {_tipo}, valores:{item}");
            }
            catch (Exception ex)
            {
                var exception = new ServiceException("Ocurrio un error al eliminar el item", ex);
                _logger.LogError(LogEvents.Service, exception, $"Ocurrio un error elimando el item con id:{id}");
                throw exception;
            }
        }

        /// <summary>
        /// Función para obtener una página a partir del número y tamaño de la página deseada
        /// </summary>
        /// <param name="pageNumber">Número de página a devolver</param>
        /// <param name="pageSize">Tamaño deseado de la página</param>
        /// <param name="orderBy">Selector del campo de ordenamiento. Necesario debido al uso de la función Skip que requiere elementos ordenados.</param>
        /// <param name="ascending">Indicador para describir si el ordenamiento es ascendente o descendente</param>
        /// <param name="predicate">Predicado para realizar el filtrado de los elementos a devolver</param>
        /// <returns>Devuelve un objeto de tipo Page</returns>
        public Page<T> GetPage<TKey>(int pageNumber, 
                                     int pageSize, 
                                     Expression<Func<T, TKey>> orderBy,
                                     bool ascending = true,
                                     Expression<Func<T, bool>> predicate = null)

        {
            var query = GetAllItems(predicate).AsExpandable();

            return GetPage(pageNumber, pageSize, query, orderBy, ascending);
        }

        /// <summary>
        /// Función para obtener una página a partir del número y tamaño de la página deseada
        /// </summary>
        /// <param name="pageNumber">Número de página a devolver</param>
        /// <param name="pageSize">Tamaño deseado de la página</param>
        /// <param name="orderBy">Selector del campo de ordenamiento. Necesario debido al uso de la función Skip que requiere elementos ordenados.</param>
        /// <param name="thenBy">Selector secundario del campo de ordenamiento. Opcional.</param>
        /// <param name="ascending">Indicador para describir si el ordenamiento es ascendente o descendente</param>
        /// <param name="predicate">Predicado para realizar el filtrado de los elementos a devolver</param>
        /// <returns>Devuelve un objeto de tipo Page</returns>
        public Page<T> GetPage<TKey, TSec>(int pageNumber,
                                           int pageSize,
                                           Expression<Func<T, TKey>> orderBy,
                                           Expression<Func<T, TSec>> thenBy = null,
                                           bool ascending = true,
                                           Expression<Func<T, bool>> predicate = null)
        {
            var query = GetAllItems(predicate).AsExpandable();

            return GetPage(pageNumber, pageSize, query, orderBy, thenBy, ascending);
        }

        /// <summary>
        /// Función para obtener una página a partir del número y tamaño de la página deseada
        /// </summary>
        /// <param name="pageNumber">Número de página a devolver</param>
        /// <param name="pageSize">Tamaño deseado de la página</param>
        /// <param name="orderBy">Selector del campo de ordenamiento. Necesario debido al uso de la función Skip que requiere elementos ordenados.</param>
        /// <param name="ascending">Indicador para describir si el ordenamiento es ascendente o descendente</param>
        /// <param name="query">Query para usar en lugar del repositorio por defecto</param>
        /// <returns>Devuelve un objeto de tipo Page</returns>
        public Page<T> GetPage<TKey>(int pageNumber,
                                     int pageSize,
                                     IQueryable<T> query,
                                     Expression<Func<T, TKey>> orderBy,
                                     bool ascending = true)
        {
            query = ascending
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);

            _logger.LogInformation(LogEvents.Service,
                "Paginando entidades del tipo {_tipo} con query: {query},ordenada por {orderBy}.",
                _tipo, query, orderBy);

            return query.ToPage(pageNumber, pageSize);
        }

        /// <summary>
        /// Función para obtener una página a partir del número y tamaño de la página deseada
        /// </summary>
        /// <param name="pageNumber">Número de página a devolver</param>
        /// <param name="pageSize">Tamaño deseado de la página</param>
        /// <param name="orderBy">Selector del campo de ordenamiento. Necesario debido al uso de la función Skip que requiere elementos ordenados.</param>
        /// <param name="thenBy">Selector secundario del campo de ordenamiento. Opcional.</param>
        /// <param name="ascending">Indicador para describir si el ordenamiento es ascendente o descendente</param>
        /// <param name="query">Query para usar en lugar del repositorio por defecto</param>
        /// <returns>Devuelve un objeto de tipo Page</returns>
        public Page<T> GetPage<TKey, TSec>(int pageNumber,
            int pageSize,
            IQueryable<T> query,
            Expression<Func<T, TKey>> orderBy,
            Expression<Func<T, TSec>> thenBy,
            bool ascending = true)
        {
            query = ascending
                ? query.OrderBy(orderBy).ThenBy(thenBy)
                : query.OrderByDescending(orderBy).ThenByDescending(thenBy);

            _logger.LogInformation(LogEvents.Service,
                $"Paginando entidades del tipo {_tipo} con query: {query},ordenada por {orderBy} y luego por {thenBy}.");

            return query.ToPage(pageNumber, pageSize);
        }

        #endregion Metodos Publicos
    }

}
    
