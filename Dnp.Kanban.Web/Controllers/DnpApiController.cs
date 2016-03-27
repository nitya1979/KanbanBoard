using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dnp.Kanban.Web.Controllers
{
    public class DnpApiController : ApiController
    {
        public IHttpActionResult DnpOk<T>(T content)
        {
            return new DnpOkResult<T>(content, this.Request);
        }

    }
}
