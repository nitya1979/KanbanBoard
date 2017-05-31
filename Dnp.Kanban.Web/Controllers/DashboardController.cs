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
    [RoutePrefix("api/user")]
    public class DashboardController : DnpApiController
    {
        private TaskService _taskService;

        public DashboardController(TaskService taskService)
        {
            if (taskService == null)
                throw new ArgumentNullException("Task Service cannot be null");

            this._taskService = taskService;

        }


        [HttpGet]
        [Route("DueTasks")]
        public async Task<IHttpActionResult> DueTasks()
        {

            List<DnpTask> tasks = await _taskService.GetDueTasks(User.Identity.Name,
                                                                 DateTime.MinValue,
                                                                 Utilities.GetWeekendDate(DateTime.Now));

            return DnpOk(tasks);
        }

    }
}
