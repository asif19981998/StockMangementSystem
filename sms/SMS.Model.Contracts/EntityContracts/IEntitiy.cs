using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model.Contracts.EntityContracts
{
    public interface IEntity
    {
        long Id { get; set; }
    }
}
