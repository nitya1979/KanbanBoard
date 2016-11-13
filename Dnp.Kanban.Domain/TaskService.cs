using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class TaskService
    {
        ITaskRepository _taskRepository = null;

        public TaskService(ITaskRepository taskRepository_)
        {
            if (taskRepository_ == null)
                throw new Exception("Task Repository must be defined.");

            this._taskRepository = taskRepository_;
        }

        public async Task<List<DnpTask>> GetTasksByProject(int projectId)
        {
            return await _taskRepository.GetTaskByProject(projectId);
        }

        public async Task<DnpTask> GetTask(int taskId)
        {
            if (taskId == 0)
                throw new Exception("taskId cannot be 0");

            return await _taskRepository.GetTask(taskId);
        }

        public async Task<int> SaveTask(DnpTask task)
        {
            if (task == null)
                throw new ArgumentNullException("Task cannot not be NULL.");

            return await _taskRepository.SaveTask(task);
        }
    }
}
