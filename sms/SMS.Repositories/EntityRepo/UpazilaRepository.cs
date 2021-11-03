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
    public class UpazilaRepository : BaseRepository<Upazila>, IUpazilaRepository
    {
        private SMSDbContext _db;
        public UpazilaRepository(SMSDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Upazila> GetUpazilasByDivisonId(int disId)
        {
            return _db.Upazilas.ToList().Where(u => u.DistrictId == disId);
        }
    }
}
