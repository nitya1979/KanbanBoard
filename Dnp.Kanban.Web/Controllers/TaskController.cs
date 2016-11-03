using Dnp.Kanban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dnp.Kanban.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Project")]
    public class TaskController : DnpApiController
    {
        private TaskService _taskService = null;

        public TaskController(TaskService taskService)
        {
            if (taskService == null)
                throw new ArgumentNullException("Task Service cannot be null");

            this._taskService = taskService;
        }

        // GET: api/Task
        [Route("{projectId}/Tasks/")]
        public async Task<IEnumerable<DnpTask>> Tasks(int projectId)
        {
            return await _taskService.GetTasksByProject(projectId);
        }

        // GET: api/Task/5
        public DnpTask Get(int id)
        {
            return _taskService.GetTask(id);
        }

        // POST: api/Task
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
        }
    }
}
