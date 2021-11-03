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
    public class UpazilaService : AppBaseService<Upazila>, IUpazilaService
    {
        private IUpazilaRepository _repository;
        public UpazilaService(IUpazilaRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _repository = iRepository;

        }

        public IEnumerable<Upazila> GetUpazilasByDivisonId(int disId)
        {
            return _repository.GetUpazilasByDivisonId(disId);
        }
    }
}
