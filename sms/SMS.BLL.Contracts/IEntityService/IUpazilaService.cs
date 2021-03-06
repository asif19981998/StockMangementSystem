using Base.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.Contracts.IEntityService
{
    public interface IUpazilaService : IMainService<Upazila>
    {
        IEnumerable<Upazila> GetUpazilasByDivisonId(int disId);
    }
}
