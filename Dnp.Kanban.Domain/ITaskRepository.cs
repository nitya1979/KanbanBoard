﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public interface ITaskRepository
    {
        Task<List<DnpTask>> GetTaskByProject(int projectId);
        DnpTask GetTask(int taskId);
        Task<int> SaveTask(DnpTask task);
    }
}
