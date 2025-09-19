using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Context;
using Sicom.Dominio.Entidades;
using Sicom.Dominio.Extensions;

namespace Sicom.Dominio.Implementation
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad
    {
        protected readonly AppDbContext _dbContext;
        public Repositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Get(ulong id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public virtual async Task<T> GetAsync(ulong id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public virtual T Get(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().Select(x => x);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Update<T>(entity);
        }

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbContext.Set<T>().Attach(entity);

            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(Func<T, bool> predicate)
        {
            var records = _dbContext.Set<T>().Where(predicate);
            foreach (var record in records)
            {
                _dbContext.Set<T>().Remove(record);
            }
        }

        public Page<T> GetPage(int pageNumber, int pageSize, string sortBy, bool ascending, string searchCriteria)
        {
            var query = _dbContext.Set<T>().Select(x => x);
            return query.ToPage(pageNumber, pageSize);
        }

    }
}
