using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Dnp.Kanban.Web.Filters
{
    public class DnpHandleErrorAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            throw new HttpResponseException(actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message
                ));

            //base.OnException(actionExecutedContext);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}