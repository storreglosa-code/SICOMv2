using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicom.Dominio.Contracts
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

}
