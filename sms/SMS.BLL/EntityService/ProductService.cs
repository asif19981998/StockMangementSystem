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
    public class ProductService : AppBaseService<Product>, IProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _repository = iRepository;

        }
    }
    }
