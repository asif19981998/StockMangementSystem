using Base.Repositories;
using Microsoft.EntityFrameworkCore;
using SMS.DataBaseContext;
using SMS.Models;
using SMS.Repositories.Abastractions.IEntity;
using System;
using System.Collections.Generic;
using System.Data;
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
                .Include(stock => stock.Upazila.District)
                .Include(stock => stock.Upazila.District.Divison)
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

        public ICollection<Stock> GetDataByUpazilaId(long id)
        {
            return _db.Stocks.Where(stock => stock.UpazilaId == id)
                .Include(stock => stock.Product)
                .Include(stock => stock.Upazila)
                .ToList();
        }

        public DataTable GetReportData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UpazilaName");
            dt.Columns.Add("DistrictName");
            dt.Columns.Add("DivisonName");
            DataRow row;
           var stockList =  _db.Stocks
                .Include(stock => stock.Product)
                .Include(stock => stock.Upazila)
                .Include(stock => stock.Upazila.District)
                .Include(stock => stock.Upazila.District.Divison)
                .ToList();
            int index = 1;
            foreach (var item in stockList)
            {
                row = dt.NewRow();
                row["Id"] = index;
                row["ProductName"] = item.Product?.Name;
                row["Quantity"] = item.Quantity;
                row["UpazilaName"] = item.Upazila?.Name;
                row["DistrictName"] = item.Upazila?.District?.Name;
                row["divisonName"] = item.Upazila?.District?.Divison?.Name;
                dt.Rows.Add(row);
                ++index;

            }

            return dt;


        }
    }
    }


