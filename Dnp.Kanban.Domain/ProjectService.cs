using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class ProjectService
    {
        private IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectReop)
        {
            if (projectReop == null)
                throw new ArgumentNullException("Project respository cannot be null");

            this._projectRepo = projectReop;
        }
    }
}
