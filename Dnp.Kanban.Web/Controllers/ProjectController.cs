﻿using Dnp.Kanban.Domain;
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
    [RoutePrefix("api/Project")]
    public class ProjectController : DnpApiController
    {
        ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            if (projectService == null)
                throw new ArgumentNullException("Project Service is undefined.");

            this._projectService = projectService;
        }
        // GET: api/Project
        public async Task< IHttpActionResult> Get()
        {

            //JsonSerializerSettings settings = new JsonSerializerSettings { DateFormatString = "MM/dd/yyyy" };

            var projectList = await _projectService.GetAllProjects();

            return DnpOk(projectList);

            //return Json<IEnumerable<Project>>(await _projectService.GetAllProjects(), settings);

        }

        // GET: api/Project/5
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var project = await _projectService.GetProject(id);

            if (project == null)
                return NotFound();

            return DnpOk(project);
        }

        // POST: api/Project
        public async Task<IHttpActionResult> Post([FromBody]Project project)
        {
            if (ModelState.IsValid)
            {
                int i = await _projectService.SaveProjectAsync(project);
                
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("Stages/{projectId:int}")]
        public async Task<IHttpActionResult> Stages( int projectId)
        {
            if (projectId == 0)
                return BadRequest("Product id not specified.");

            var projectStageList = await _projectService.GetProjectStages(projectId);

            if (projectStageList.Count() == 0)
                return BadRequest("Product doesn't exist.");

            return DnpOk(projectStageList);
        }
    }
}
