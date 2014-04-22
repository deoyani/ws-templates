using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvc4_template.Models;

namespace mvc4_template.Controllers
{
    public class CustomResponseController : ApiController
    {
        // GET api/customresponse
        public HttpResponseMessage Get()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new CustomResponse("This is a custom response"), "application/xml");
            //return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new CustomResponse("This is a custom response"), "application/json");
            //return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new CustomResponse("This is a custom response"), "text/plain");
        }
    }
}
