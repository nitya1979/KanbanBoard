using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dnp.Kanban.Domain;
using AutoMapper;

namespace Dnp.Kanban.SqlRepository
{
    public class SqlProjectRepository : IProjectRepository, IDisposable
    {
        KanbanDbContext _kanbanContext = null;

        public SqlProjectRepository(string defaultConnection)
        {
            _kanbanContext = new KanbanDbContext(defaultConnection);
        }

        public void Dispose()
        {
            if (_kanbanContext != null)
                _kanbanContext.Dispose();
        }

        public Project GetProject(int id)
        {
            var project = _kanbanContext.DbProjects.Find(id);
            Project p = Mapper.Map<Project>(project);
            return p;
        }

        public List<Project> GetProjectList()
        {
            List<DbProject> dbProjs = _kanbanContext.DbProjects.ToList();

            List<Project> projectList = new List<Project>();

            foreach (DbProject item in dbProjs)
            {
                projectList.Add(Mapper.Map<Project>(item));
            }

            return projectList;
        }

        public List<ProjectStage> GetProjectStages(int projectId)
        {
            var dbProjectStages = _kanbanContext.DbProjectStage.Where(s => s.ProjectID == projectId).ToList();

            List<ProjectStage> stage = new List<ProjectStage>();

            foreach (var item in dbProjectStages)
            {
                stage.Add(Mapper.Map<ProjectStage>(item));
            }

            return stage;
        }

        public async Task<int> SaveProject(Project project)
        {
            DbProject dbProject = Mapper.Map<DbProject>(project);
            
            if (project.ID == 0)
            {
                dbProject.Stages = new List<DbProjectStage>();
                dbProject.Stages.Add(new DbProjectStage { StageName = "Back Log" });
                dbProject.Stages.Add(new DbProjectStage { StageName = "In Progress" });
                dbProject.Stages.Add(new DbProjectStage { StageName = "Completed" });

                _kanbanContext.DbProjects.Add(dbProject);
            }
            else
                _kanbanContext.Entry<DbProject>(dbProject).State = EntityState.Modified;

            return await _kanbanContext.SaveChangesAsync();
        }
    }
}
