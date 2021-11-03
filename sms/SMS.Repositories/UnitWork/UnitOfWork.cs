

using AmarDaktar.Repositories.Abastractions.IUnitWork;
using SMS.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmarDaktar.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SMSDbContext _db;
        public UnitOfWork(SMSDbContext db)
        {
            _db = db; 
        }
     
        public bool SaveChanges()
        {
            return _db.SaveChanges() >0;
        }

        
        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
