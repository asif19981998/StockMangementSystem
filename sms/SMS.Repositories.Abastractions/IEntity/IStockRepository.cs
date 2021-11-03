using Base.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repositories.Abastractions.IEntity
{
  
    public interface IStockRepository : IMainRepository<Stock>
    {
        ICollection<Stock> GetChartData();
    }
}
