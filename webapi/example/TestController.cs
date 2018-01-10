using System.Web.Http;

namespace webapi.example
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("this is TestController.Get()");
        }
    }
}
