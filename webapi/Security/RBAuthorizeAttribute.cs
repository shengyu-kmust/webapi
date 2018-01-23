using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Controllers;
using webapi.Entities;
using webapi.Services;

namespace webapi.Security
{
    /// <summary>
    /// Role Basic AuthorizeAttribute（基于角色的授权）
    /// </summary>
    public class RBAuthorizeAttribute : AuthorizeAttribute
    {
        public string Description { set; get; }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // 这是base.IsAuthorized里的逻辑
            //IPrincipal principal = actionContext.ControllerContext.RequestContext.Principal;
            //return principal != null && principal.Identity != null 
            //    && principal.Identity.IsAuthenticated && 
            //    (
            //        (this._usersSplit.Length <= 0 || ((IEnumerable<string>)this._usersSplit).Contains<string>(principal.Identity.Name, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)) 
            //        && 
            //        (this._rolesSplit.Length <= 0 || ((IEnumerable<string>)this._rolesSplit).Any<string>(new Func<string, bool>(principal.IsInRole)))
            //     );

            // 下在可替换成自己的授权逻辑代码
            AuthorizeService authorizeService =new AuthorizeService(new DB());
            var resourceName = actionContext.ActionDescriptor.GetCustomAttributes<RBAuthorizeAttribute>().Any()
                ? actionContext.ActionDescriptor.ActionName
                : actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var roleNames = authorizeService.GetResourceRoleNames(resourceName);
            IPrincipal principal = actionContext.ControllerContext.RequestContext.Principal;
            return principal != null && principal.Identity != null
                && principal.Identity.IsAuthenticated &&
                (
                    (((IEnumerable<string>)roleNames).Any<string>(new Func<string, bool>(principal.IsInRole)))
                 );
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response =
               actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "未授权");
        }
    }
}