using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RunShawn.Web.Api
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

            return response;
        }

    }
}