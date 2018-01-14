using System;
using System.Web.Http;
using log4net;

/// <summary>
/// 日志处理测试接口，使用log4net
/// </summary>
namespace webapi.example
{
    public class LogTestController : ApiController
    {
        private ILog _log;

        public LogTestController(ILog log)
        {
            _log = log;
        }
        public IHttpActionResult Get()
        {
            _log.Debug("测试debug",new Exception("debug异常"));
            _log.Info("测试Info", new Exception("Info异常"));
            _log.Warn("测试Warn", new Exception("Warn异常"));
            _log.Error("测试Error", new Exception("Error异常"));
            _log.Fatal("测试Fatal", new Exception("Fatal异常"));
            return Ok("已经写入日志");
        }
    }
}
