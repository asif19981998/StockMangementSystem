using Base.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.Contracts.IEntityService
{
    public interface IStockService : IMainService<Stock>
    {
        ICollection<Stock> GetChartData();
        DataTable GetReportData();
        ICollection<Stock> GetDataByUpazilaId(long id);
    }
}
