using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dnp.Kanban.Web.Controllers
{
    public class DnpOkResult<T> : IHttpActionResult
    {
        private T _content;
        private HttpRequestMessage _request;
        JsonSerializerSettings _settings = new JsonSerializerSettings { DateFormatString = "MM/dd/yyyy" };

        public DnpOkResult(T content, HttpRequestMessage request)
        {
            this._content = content;
            this._request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage message = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(_content, _settings)),
                RequestMessage = this._request
            };

            return Task.FromResult(message);    
        }
    }
}
