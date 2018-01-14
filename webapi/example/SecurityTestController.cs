using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using webapi.Common;

namespace webapi.example
{
    [RoutePrefix("api/security")]
    public class SecurityTestController : ApiController
    {
        /// <summary>
        /// 通过get请求里传过来的值生成token
        /// </summary>
        /// <returns></returns>
        [Route("token"),HttpGet]
        public IHttpActionResult GetToken()
        {
            var dic=new Dictionary<string,object>();
            foreach (var queryNameValuePair in Request.GetQueryNameValuePairs())
            {
                dic.Add(queryNameValuePair.Key,queryNameValuePair.Value);
            }
            var token=new JWTHelper().Encode(dic, "shengyu",30);
            return Ok(token);
        }

        /// <summary>
        /// 返回token里加密的信息
        /// </summary>
        /// <returns></returns>
        [Route("GetUserInfoFromToken"),HttpGet]
        public IHttpActionResult GetUser()
        {
            var user = (ClaimsPrincipal)User;
            var dic=new Dictionary<string,object>();
            foreach (var userClaim in user.Claims)
            {
                dic.Add(userClaim.Type,userClaim.Value);
            }
            return Ok(dic);
        }
    }
    
}
