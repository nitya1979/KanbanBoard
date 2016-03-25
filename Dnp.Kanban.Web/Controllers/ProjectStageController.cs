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
    public class ProjectStageController : ApiController
    {
        ProjectService _projectService;

        public ProjectStageController(ProjectService projectService_)
        {
            this._projectService = projectService_;
        }

        // GET: api/ProjectStage
        public async Task<IEnumerable<ProjectStage>> Get(int projectId)
        {
            //if (projectId == 0)
            //    return BadRequest();

            return await this._projectService.GetProjectStages(projectId);
        }

        // POST: api/ProjectStage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProjectStage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProjectStage/5
        public void Delete(int id)
        {
        }
    }
}
