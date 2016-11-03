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
        public DnpTask GetTask(int taskId)
        {
            DbTask task = _dbContext.DbTask.Find(taskId);

            return Mapper.Map<DnpTask>(task);
        }

        public Task<List<DnpTask>> GetTaskByProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveTask(DnpTask task)
        {
            throw new NotImplementedException();
        }
    }
}
