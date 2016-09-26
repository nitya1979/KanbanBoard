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
    [RoutePrefix("api/Common")]
    public class CommonController : DnpApiController
    {
        CommonDataService _dataService;
        public CommonController(CommonDataService dataService_)
        {
            if (dataService_ == null)
                throw new ArgumentNullException("Common dataservice is undefined.");

            this._dataService = dataService_;
        }

        [HttpGet]
        [Route("Priorities")]
        public async Task<IHttpActionResult> Priorities()
        {
            var priorities = await _dataService.GetPriorites();

            return DnpOk(priorities);
        }
    }
}
