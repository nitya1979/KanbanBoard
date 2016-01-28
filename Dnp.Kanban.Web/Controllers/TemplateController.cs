using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnp.Kanban.Web.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        // GET: Template
        [AllowAnonymous]
        public ActionResult GetTemplate(string template)
        {
            return PartialView(template);
        }

        [Authorize]
        public ActionResult GetAuthTemplate(string template)
        {
            return PartialView(template);
        }
    }
}