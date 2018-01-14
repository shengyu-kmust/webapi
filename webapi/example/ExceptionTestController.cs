using System;
using System.Web.Http;
using webapi.Exceptions;

namespace webapi.example
{
    [RoutePrefix("api/exceptionTest")]
    public class ExceptionTestController : ApiController
    {
        /// <summary>
        /// 模拟程序bug抛出的异常
        /// </summary>
        /// <returns></returns>
        [Route("unknown"),HttpGet]
        public IHttpActionResult UnKnow()
        {
            throw new Exception("未知的异常");
        }
        /// <summary>
        /// 模拟主动抛出的业务异常
        /// </summary>
        /// <returns></returns>
        [Route("known"), HttpGet]
        public IHttpActionResult Know()
        {
            throw new KnownException("已知的异常");
        }
    }
}
