using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using webapi.Common;
using webapi.Security;

namespace webapi.example
{
    [RoutePrefix("api/security"), RBAuthorize(Roles = "role",Description = "测试权限控制器")]
    //[RoutePrefix("api/security"),RBAuthorize(Description = "SecurityTestController")]
    public class SecurityTestController : ApiController
    {
        /// <summary>
        /// 通过get请求里传过来的值生成token
        /// </summary>
        /// <returns></returns>
        [Route("token"),HttpGet,AllowAnonymous]
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
        [Route("GetUserInfoFromToken"),HttpGet, AllowAnonymous]
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

        #region 硬编码的方式实现简单的权限控制

        /// <summary>
        /// 只有某种角色的用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("byCode/onlyRoles"), RBAuthorize(Roles = "admin,superAdmin",Description = "OnlyRoles_SetByCode"),HttpGet]
        public IHttpActionResult OnlyRoles_SetByCode()
        {
            return Ok("OnlyRoles_SetByCode,仅管理员能访问");
        }

        /// <summary>
        /// 只有某种角色的用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("byCode/onlyRoles2"), RBAuthorize(Roles = "user,member",Description = "OnlyRoles_SetByCode2"), HttpGet]
        public IHttpActionResult OnlyRoles_SetByCode2()
        {
            return Ok("OnlyRoles_SetByCode2,仅角色为user,member能访问");
        }

        /// <summary>
        /// 只有某几个用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("byCode/onlyUsers"), RBAuthorize(Users = "张三,李四",Description = "OnlyUsers_SetByCode"),HttpGet]
        public IHttpActionResult OnlyUsers_SetByCode()
        {
            return Ok("OnlyRoles_SetByCode,仅张三和李四才能访问");
        }
        #endregion

        #region 配置的方式实现基于角色的权限控制

        [Route("dynamic/onlyRoles1"), RBAuthorize(Description = "Dynamic_OnlyRoles1"), HttpGet]
        public IHttpActionResult Dynamic_OnlyRoles1()
        {
            return Ok("成功访问Dynamic_OnlyRoles1");
        }
        [Route("dynamic/onlyRoles2"), RBAuthorize(Description = "Dynamic_OnlyRoles2"), HttpGet]
        public IHttpActionResult Dynamic_OnlyRoles2()
        {
            return Ok("成功访问Dynamic_OnlyRoles2");
        }
        [Route("dynamic/onlyRoles3"), AllowAnonymous, HttpGet]
        public IHttpActionResult Dynamic_OnlyRoles3()
        {
            return Ok("成功访问Dynamic_OnlyRoles3，此方法不需要权限及可访问");
        }
        #endregion
    }
    
}
