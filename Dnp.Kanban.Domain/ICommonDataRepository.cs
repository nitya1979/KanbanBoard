using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public interface ICommonDataRepository
    {
        Task<List<DnpPriority>> GetPriorities();
    }
}
