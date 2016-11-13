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
                var tasks = _dbContext.DbProjectStage.Join(_dbContext.DbTask, p => p, t => t.ProjectStage, (p, t) => t).ToList();

                List<DnpTask> dnpTasks = new List<DnpTask>();
                foreach (DbTask t in tasks)
                {
                    dnpTasks.Add(Mapper.Map<DnpTask>(t));
                }

                return dnpTasks;
            });
        }

        public Task<int> SaveTask(DnpTask task)
        {
            throw new NotImplementedException();
        }
    }
}
