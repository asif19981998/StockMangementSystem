using Base.Repositories;
using Microsoft.EntityFrameworkCore;
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
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private SMSDbContext _db;
        public StockRepository(SMSDbContext db) : base(db)
        {
            _db = db;
        }
        public override ICollection<Stock> GetAll()
        {
            return _db.Stocks
                .Include(stock => stock.Product)
                .Include(stock => stock.Upazila)
                .ToList();


        }
        public ICollection<Stock> GetChartData()
        {
            List<Stock> result = _db.Stocks
                 .Include(stock => stock.Upazila)
                 .ToList()
                .GroupBy(x => x.UpazilaId)
                .Select(st => new Stock
                {
                    UpazilaId = st.First().UpazilaId,
                    Upazila = st.First().Upazila,
                    Quantity = st.Sum(q => q.Quantity)
                }).ToList();

            return result;


        }

    }
    }


