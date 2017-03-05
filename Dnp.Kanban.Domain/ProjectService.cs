using System;
using System.Linq;
using System.Collections.Generic;
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

        public Task<IEnumerable<Project>> GetAllProjects()
        {
            return Task.Factory.StartNew<IEnumerable<Project>>(() => { return _projectRepo.GetProjectList(); }) ;
        }

        public Task<Project> GetProject(int id)
        {
            return Task.Factory.StartNew<Project>(() => { return _projectRepo.GetProject(id); });
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
           return await Task.Factory.StartNew<int>(() =>
            {
                return _projectRepo.SaveProject(project).Result;

            });
            
        }

        public async Task<IEnumerable<ProjectStage>> GetProjectStages(int projectId)
        {
            return await Task.Factory.StartNew<IEnumerable<ProjectStage>>(() =>
            {
                return _projectRepo.GetProjectStages(projectId);
            });
        }

        public async Task<IEnumerable<DnpTask>> GetProjectTasks(int projectId)
        {
            return await _projectRepo.GetProjectTask(projectId);
        }

        public Task<DnpTask> GetTask(int taskId)
        {
            return Task.Factory.StartNew<DnpTask>(() =>
            {
                return _projectRepo.GetTask(taskId);
            });
        }

        public Task<int> SaveStage(ProjectStage stage)
        {
            if (stage.ProjectID == 0)
                throw new InvalidOperationException("Project ID must be defined.");
            
            List<ProjectStage> currentStages = _projectRepo.GetProjectStages(stage.ProjectID);

            if (currentStages.Any(s => s.StageName.Equals(stage.StageName) && stage.ID == 0))
                throw new InvalidOperationException(string.Format("Stage '{0}' already exists", stage.StageName));

            
            return _projectRepo.SaveStage(stage);
        }
    }
}
