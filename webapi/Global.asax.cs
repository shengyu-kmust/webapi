using System;
using System.Web.Http;
using webapi.Configs;


namespace webapi
{
    /// <summary>
    /// 部署在iis里时，iis的入口为HttpApplication.Application_Start函数，所以webapi要在此函数里做配置。
    /// 如果用owin通道（iis的asp.net pipeline 将不再启用），则不需要Global.asax文件
    /// 在部署时如果是用owin技术，Global.asax不用删除，请求是不会进过这里的，除非删除了bin目录下的Microsoft.Owin.Host.SystemWeb.dll
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            #region webapi的相关配置
            // GlobalConfiguration类在Microsoft.AspNet.WebApi.Core里，用nuget添加Microsoft.AspNet.WebApi
            //GlobalConfiguration类在Microsoft.AspNet.WebApi.WebHost里有也定义
            GlobalConfiguration.Configure(WebApiConfig.Register);

            #endregion

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}