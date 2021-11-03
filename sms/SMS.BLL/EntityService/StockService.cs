using AmarDaktar.Repositories.Abastractions.IUnitWork;
using AmarDaktarApp.AppBaseControllerServiceRepository;
using SMS.BLL.Contracts.IEntityService;
using SMS.Models;
using SMS.Repositories.Abastractions.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.EntityService
{
    public class StockService : AppBaseService<Stock>,IStockService
    {
        private IStockRepository _repository;
        public StockService(IStockRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _repository = iRepository;

        }
        public ICollection<Stock> GetChartData()
        {
            return _repository.GetChartData();




        }
    }
    }
