using AutoMapper;
using Dnp.Kanban.Domain;
using Dnp.Kanban.ViewModel;
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
        private ProjectService _projectService = null;

        public TaskController(TaskService taskService, ProjectService projectService)
        {
            if (taskService == null)
                throw new ArgumentNullException("Task Service cannot be null");
            if (projectService == null)
                throw new ArgumentNullException("Project Service cannot be null");

            this._taskService = taskService;
            this._projectService = projectService;
        }

        // GET: api/Task
        [HttpGet]
        [Route("{projectId:int}/Tasks/")]
        public async Task<IHttpActionResult> Tasks(int projectId)
        {
            List<DnpTask> dnpTask = await _taskService.GetTasksByProject(projectId);

            return DnpOk(Mapper.Map<List<DnpTask>, List<DnpTaskViewModel>>(dnpTask));
        }

        // GET: api/Task/5
        [HttpGet]
        [Route("{projectId:int}/Task/{id:int}")]
        public async Task<IHttpActionResult> Get(int id, int projectId = 0)
        {
            DnpTask task = await _taskService.GetTask(id);

            return DnpOk(Mapper.Map<DnpTaskViewModel>(task));
        }

        // POST: api/Task
        [HttpPost]
        [Route("{projectId:int}/Task/")]
        public async Task<int> Post([FromBody]DnpTaskViewModel task, int projectId = 0)
        {
            IEnumerable<ProjectStage> stages = await _projectService.GetProjectStages(projectId);

            ProjectStage backLog = stages.ToList()[0];

            task.StageID = backLog.ID;

            return await this._taskService.SaveTask(Mapper.Map<DnpTask>(task));
                
        }

        // PUT: api/Task/5
        [HttpPut]
        [Route("{projectId:int}/Task/{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]DnpTaskViewModel task, int projectId = 0)
        {
            List<ProjectStage> stages =( await _projectService.GetProjectStages(projectId)).ToList();
            
            if ( id != task.TaskID  )
            {
                ModelState.AddModelError("TaskID", "Invalid Task Id");
            }

            if(!(stages.Any(s => s.ID == task.StageID)))
            {
                ModelState.AddModelError("Stage", "Stage doesn't belong to this project.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int result = await this._taskService.SaveTask(Mapper.Map<DnpTask>( task));

            return DnpOk(result);
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
        }
    }
}
