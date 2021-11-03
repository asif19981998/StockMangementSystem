using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmarDaktar.Repositories.Abastractions.IUnitWork
{
    public interface IUnitOfWork:IDisposable
    {
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
