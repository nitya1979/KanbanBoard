﻿using System;
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

        public async Task DeleteTask(int taskId)
        {
            if (taskId == 0)
                throw new ArgumentException("Invalid task ID passed.  Value should be greater then 0.");

            await _taskRepository.Delete(taskId);
        }

        public async Task<List<DnpTask>> GetDueTasks(string userId, DateTime from, DateTime toDate)
        {

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("User Id cancnot be null.");

            return await _taskRepository.GetTaskByUser(userId, from, toDate, false);
        
        }
    }
}
