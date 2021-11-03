
using AmarDaktar.Repositories.Abastractions.IUnitWork;
using Base.Contracts;
using Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarDaktarApp.AppBaseControllerServiceRepository
{
    public class AppBaseService<T>: BaseService<T> where T:class
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public AppBaseService(IMainRepository<T> iRepository, IUnitOfWork iUnitOfWork):base(iRepository)
        {
           
            _unitOfWork = iUnitOfWork;
        }
        public bool SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }


    }
}
