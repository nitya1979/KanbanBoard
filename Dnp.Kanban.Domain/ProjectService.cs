﻿using System;
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
    }
}
