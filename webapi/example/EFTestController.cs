using System.Linq;
using System.Web.Http;
using webapi.Entities;

namespace webapi.example
{
    public class EFTestController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (DB db=new DB())
            {
                var list = db.TestTables;
                return Ok(list.ToList());
            }
        }
    }
}
