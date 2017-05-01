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

        public List<Project> GetProjectList(int? page, int? count)
        {
            List<DbProject> dbProjs;

            if (page == null && count == null)
                dbProjs = _kanbanContext.DbProjects.OrderByDescending(p => p.StartDate).ToList();
            else
                dbProjs = _kanbanContext.DbProjects.OrderByDescending(p => p.StartDate)
                                                               .Skip(page.Value * count.Value)
                                                               .Take(count.Value)
                                                               .ToList();

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

        public List<ProjectSummary> GetProjectSummary(int? page, int? count)
        {
            List<DbProject> dbProjs;

            if (page == null && count == null)
                dbProjs = _kanbanContext.DbProjects.OrderByDescending(p => p.StartDate).Include( p => p.Stages).ToList();
            else
                dbProjs = _kanbanContext.DbProjects.OrderByDescending(p => p.StartDate)
                                                               .Skip(page.Value * count.Value)
                                                               .Take(count.Value).Include( p => p.Stages)
                                                               .ToList();

            List<ProjectSummary> summary = new List<ProjectSummary>();

            foreach (DbProject proj in dbProjs)
            {
            
                ProjectSummary summ = new ProjectSummary
                {
                    ProjectID = proj.ID,
                    Name = proj.Name,
                    Description = proj.Description,
                    StartDate = proj.StartDate,
                    EndDate = proj.EndDate,
                };

                summary.Add(summ);

                var backlog = proj.Stages.OrderBy(s => s.Order).FirstOrDefault();
                var completed = proj.Stages.OrderByDescending(s => s.Order).FirstOrDefault();


                var tasks = _kanbanContext.DbProjectStage.Join(_kanbanContext.DbTask, p => p, t => t.ProjectStage, (p, t) => new { p, t })
                                    .Where(o => o.p.ProjectID == proj.ID)
                                    .Select(j => new { taskId = j.t.TaskID, stageId = j.t.ProjectStageID }).ToList();

                int bakLogCnt = tasks.Where(t => t.stageId == backlog.ID).Count();
                int completdCnt = tasks.Where(t => t.stageId == completed.ID).Count();

                int inProgressCnt = tasks.Where(t => t.stageId != backlog.ID && t.stageId != completed.ID).Count();

                summ.ChartLabel = new string[] { "Back Log", "In Progress", "Completed" };
                summ.ChartData = new int[] { bakLogCnt, inProgressCnt, completdCnt };

            }

            return summary;
        }

        public async Task<List<DnpTask>> GetProjectTask(int projectId)
        {
            var tasks = await (from t in _kanbanContext.DbTask
                        join s in _kanbanContext.DbProjectStage on t.ProjectStageID equals s.ID
                        where s.ProjectID == projectId
                        select Mapper.Map<DnpTask>( t)).ToListAsync();

            return tasks;
                       
        }

        public DnpTask GetTask(int taskId)
        {
            if (taskId == 0)
                throw new Exception("TaskID is undefined.");

            var task = _kanbanContext.DbTask.Find(taskId);

            return Mapper.Map<DnpTask>(task);
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

            await _kanbanContext.SaveChangesAsync();

            return dbProject.ID;
        }

        public Task<int> SaveStage(ProjectStage stage)
        {
            DbProjectStage dbStage = Mapper.Map<DbProjectStage>(stage);

            if (dbStage.ID == 0)
            {
                dbStage.Order = (short)(_kanbanContext.DbProjectStage.Max( s => s.Order));
                _kanbanContext.DbProjectStage.Add(dbStage);
                
            }
            else
            {
                foreach (var dbStg in _kanbanContext.DbProjectStage.Where( s => s.Order >= stage.Order))
                {
                    dbStg.Order++;
                }

                DbProjectStage db = _kanbanContext.DbProjectStage.Single(d => d.ID == dbStage.ID);


                db.StageName = stage.StageName;
                db.Order = stage.Order;
            }
                

            return _kanbanContext.SaveChangesAsync();
        }

        public async Task<int> SaveTask(DnpTask task)
        {

            DbTask dbTask = Mapper.Map<DbTask>(task);

            if( dbTask.TaskID == 0)
            {
                _kanbanContext.DbTask.Add(dbTask);
            }
            else
            {
                _kanbanContext.Entry<DbTask>(dbTask).State = EntityState.Modified;
            }

            return await _kanbanContext.SaveChangesAsync();
        }
    }
}
