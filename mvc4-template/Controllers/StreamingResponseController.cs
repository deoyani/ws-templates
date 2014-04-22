using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using mvc4_template.Models;

namespace mvc4_template.Controllers
{
    public class StreamingResponseController : ApiController
    {
        // GET api/streamingresponse
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse();
            StreamingResponse streamingResponse = new StreamingResponse();
            response.Content = new PushStreamContent(streamingResponse.WriteToStream, new MediaTypeHeaderValue("text/plain"));
            return response;
        }
    }
}
