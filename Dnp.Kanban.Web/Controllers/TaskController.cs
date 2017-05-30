using AutoMapper;
using Dnp.Kanban.Domain;
using Dnp.Kanban.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("{projectId:int}/Tasks")]
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
        public async Task<IHttpActionResult> Post([FromBody]DnpTaskViewModel task, int projectId = 0)
        {
            IEnumerable<ProjectStage> stages = await _projectService.GetProjectStages(projectId);

            ProjectStage backLog = stages.ToList()[0];

            task.ProjectStageID = backLog.ID;
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DnpTask dntpTask = Mapper.Map<DnpTask>(task);
            dntpTask.UserID = User.Identity.Name;
            int result = await this._taskService.SaveTask(dntpTask);

            return DnpOk(result);
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

            if(!(stages.Any(s => s.ID == task.ProjectStageID)))
            {
                ModelState.AddModelError("Stage", "Stage doesn't belong to this project.");
            }

            DnpTask dnpTask = Mapper.Map<DnpTask>(task);

            //if task is at last stage, mark it complete
            ProjectStage lastStage =  stages.OrderByDescending(s => s.Order).FirstOrDefault();
            
            dnpTask.IsCompleted = task.ProjectStageID == lastStage.ID;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int result = await this._taskService.SaveTask(Mapper.Map<DnpTask>( task));

            return DnpOk(result);
        }

        // DELETE: api/Task/5
        [HttpDelete]
        [Route("{projectId:int}/Task/{id:int}")]
        public async Task Delete(int id, int projectId = 0)
        {
            await _taskService.DeleteTask(id);
        }

        [HttpGet]
        [Route("{projectId:int}/ChartData")]
        public async Task<IHttpActionResult> ChartData(int projectId)
        {

            var taskList = await _taskService.GetTasksByProject(projectId);
            var stageList = await _projectService.GetProjectStages(projectId);

            var lastStage = stageList.OrderByDescending(s => s.Order).FirstOrDefault();
            var firstStage = stageList.OrderBy(s => s.Order).FirstOrDefault();

            int baclog = taskList.Where(t => t.ProjectStageID == firstStage.ID).Count();
            int completed = taskList.Where(t => t.ProjectStageID == lastStage.ID).Count();

            int inprogress = taskList.Where(t => t.ProjectStageID != firstStage.ID && t.ProjectStageID != lastStage.ID).Count();

            var chartData = new
            {
                Label = new string[] { "Back Log", "In Progress", "Completed" },
                Data = new int[] { baclog, inprogress, completed }
            };

            return DnpOk(chartData);
        }

        
    }
}
