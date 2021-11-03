using SMS.Model.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmarDaktar.Model.Contracts.EntityContracts
{
    public interface IDeleteAble:IEntity
    {
        bool IsDeleted { get; set; }
        long? DeletedById { get; set; }
        DateTime? DeletedOn { get; set; }

    }
}
