using System.Web.Http;
/// <summary>
/// 本代码用来测试依赖注入是否正常
/// </summary>
namespace webapi.example
{
    public class IOCTestController : ApiController
    {
        private People _people;
        public IOCTestController(People people)
        {
            _people = people;
        }

        public IHttpActionResult GetLanguage()
        {
            return Ok(_people.Language());
        }
    }

    public interface People
    {
        string Language();
    }

    public class Chinese : People
    {
        public string Language()
        {
            return "汉语";
        }
    }

    public class American:People
    {
        public string Language()
        {
            return "english";
        }
    }
}
