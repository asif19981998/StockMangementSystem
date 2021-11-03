using Base.Repositories;
using SMS.DataBaseContext;
using SMS.Models;
using SMS.Repositories.Abastractions.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repositories.EntityRepo
{
    public class DivisonRepository : BaseRepository<Divison>, IDivisonRepository
    {
        private SMSDbContext _db;
        public DivisonRepository(SMSDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
