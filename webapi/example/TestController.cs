using System.Web.Http;
using webapi.Entities;
using webapi.Services;

namespace webapi.example
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [Route("get"),HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("this is TestController.Get()");
        }

        [Route("Test"), HttpGet]
        public IHttpActionResult Test()
        {
            ResourceService service = new ResourceService(new DB());
            service.UpdateWebApiResource();
            return Ok("成功更新");
        }
    }
}
