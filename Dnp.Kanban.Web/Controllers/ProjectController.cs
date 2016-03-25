using Dnp.Kanban.Domain;
using Dnp.Kanban.Web.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Dnp.Kanban.Web.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            if (projectService == null)
                throw new ArgumentNullException("Project Service is undefined.");

            this._projectService = projectService;
        }
        // GET: api/Project
        public async Task< JsonResult< IEnumerable<Project>>> Get()
        {

            ModelState.AddModelError("project id", "Not valid Id");

            //if (ModelState.IsValid)
            //{
                JsonSerializerSettings settings = new JsonSerializerSettings { DateFormatString = "MM/dd/yyyy" };

                return Json<IEnumerable<Project>>(await _projectService.GetAllProjects(), settings);
            //}
            //else
            //{
            //    throw new InvalidModelStateResult
            //}
        }

        // GET: api/Project/5
        public async Task<JsonResult<Project>> Get(int id)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings { DateFormatString = "MM/dd/yyyy" };

            return Json(await _projectService.GetProject(id), settings);
        }

        // POST: api/Project
        public async Task<JsonResult<Result>> Post([FromBody]Project project)
        {
            return Json<Result>(await _projectService.SaveProjectAsync(project));
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }

        public async Task<JsonResult< IEnumerable<ProjectStage>>> Stages( int projectId)
        {
            if (projectId == 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Project Id cannot be null or 0."));

            return Json<IEnumerable<ProjectStage>>(await _projectService.GetProjectStages(projectId));
        }
    }
}
