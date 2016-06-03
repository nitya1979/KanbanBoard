using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public interface IProjectRepository
    {
        List<Project> GetProjectList();

        List<ProjectStage> GetProjectStages(int projectId);

        Project GetProject(int id);

        Task<int> SaveProject(Project project);

        Task< List<DnpTask>> GetProjectTask(int projectId);
    }
}
