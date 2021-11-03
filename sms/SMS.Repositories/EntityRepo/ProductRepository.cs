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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private SMSDbContext _db;
        public ProductRepository(SMSDbContext db) : base(db)
        {
            _db = db;
        }
    }

}
