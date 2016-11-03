using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class CommonDataService
    {
        private ICommonDataRepository _repository;

        public CommonDataService(ICommonDataRepository repository_)
        {
            if (repository_ == null)
                throw new ArgumentNullException("ICommonDataRepository", "Repository is not defined.");

            this._repository = repository_;
        }

        public async Task<IEnumerable<DnpPriority>> GetPriorites()
        {
            return await this._repository.GetPriorities();
        }
    }
}
