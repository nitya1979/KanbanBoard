using AutoMapper;
using Dnp.Kanban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    public class SqlTaskRepository : ITaskRepository
    {
        KanbanDbContext _dbContext = null;

        public SqlTaskRepository(string defaultConnection)
        {
            _dbContext = new KanbanDbContext(defaultConnection);

        }

        public async Task Delete(int taskId)
        {
            DbTask task = await _dbContext.DbTask.FindAsync(taskId);

            if (task != null)
            {
                _dbContext.DbTask.Remove(task);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<DnpTask> GetTask(int taskId)
        {
            DbTask task = await _dbContext.DbTask.FindAsync(taskId);

            return Mapper.Map<DnpTask>(task);
        }

        public Task<List<DnpTask>> GetTaskByProject(int projectId)
        {
            return Task.Factory.StartNew<List<DnpTask>>(() =>
            {
                var tasks = _dbContext.DbProjectStage.Join(_dbContext.DbTask, p => p, t => t.ProjectStage, (p, t) => new { p, t })
                                                     .Where( o => o.p.ProjectID == projectId)
                                                     .Select( j => j.t).ToList();

                List<DnpTask> dnpTasks = new List<DnpTask>();
                foreach (DbTask t in tasks)
                {
                    dnpTasks.Add(Mapper.Map<DnpTask>(t));
                }

                return dnpTasks;
            });
        }

        public Task<List<DnpTask>> GetTaskByUser(string userId, DateTime fromDate, DateTime toDate, bool isCompleted = false)
        {
            return Task.Factory.StartNew < List<DnpTask>>(() =>
            {
                List<DnpTask> tasks = (from t in _dbContext.DbTask
                                       join s in _dbContext.DbProjectStage on t.ProjectStageID equals s.ID
                                       join p in _dbContext.DbProjects on s.ProjectID equals p.ID
                                       where t.UserID == userId && t.DueDate.Value >= fromDate && t.DueDate <= toDate && t.IsCompleted == isCompleted
                                       select new DnpTask
                                       {
                                           TaskID = t.TaskID,
                                           ShortDescription = t.ShortDescription,
                                           LongDescription = t.LongDescription,
                                           Priority = (Priority)t.Priority,
                                           DueDate = t.DueDate,
                                           ProjectStageID = t.ProjectStageID,
                                           IsCompleted = t.IsCompleted,
                                           UserID = t.UserID,
                                           ProjectName = p.Name,
                                           StageName = s.StageName,
                                           ProjectID = p.ID
                                      }).ToList();

                return tasks;
            });
        }

        public async Task<int> SaveTask(DnpTask task)
        {
            DbTask dbTask = Mapper.Map<DbTask>(task);

            _dbContext.DbTask.Add(dbTask);

            if (dbTask.TaskID == 0)
                _dbContext.DbTask.Add(dbTask);
            else
                _dbContext.Entry<DbTask>(dbTask).State = System.Data.Entity.EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return dbTask.TaskID;
        }
    }
}
