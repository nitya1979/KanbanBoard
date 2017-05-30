using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public interface IProjectRepository
    {
        List<Project> GetProjectList(string userId,int? page, int? count );

        List<ProjectSummary> GetProjectSummary(string userId, int? page, int? count);

        List<ProjectStage> GetProjectStages( int projectId);

        Project GetProject(int id);

        Task<int> SaveProject(Project project);

        Task< List<DnpTask>> GetProjectTask(int projectId);

        DnpTask GetTask(int taskId);

        Task<int> SaveTask(DnpTask task);

        Task<int> SaveStage(ProjectStage stage);
    }
}
