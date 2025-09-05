using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Context;
using Sicom.Dominio.Constants;

namespace Sicom.Dominio.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(AppDbContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public int SaveChanges()
        {
            _logger.LogInformation(LogEvents.Service, "Ejecutando SaveChanges");
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            _logger.LogInformation(LogEvents.Service, "Ejecutando SaveChangesAsync");
            return await _dbContext.SaveChangesAsync();
        }
    }
}