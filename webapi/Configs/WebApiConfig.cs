using System.Web.Http;
using webapi.Exceptions;
using webapi.Security;

namespace webapi.Configs
{
    /// <summary>
    /// webapi 配置类
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 做为委托提供给System.Web.Http.GlobalConfiguration.Configuration()
        /// 用于webapi以iis为服务器的情况
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        /// <summary>
        /// 返回webapi的httpconfiguration配置
        /// 用于webapi应用于owin技术时使用
        /// </summary>
        /// <returns></returns>
        public static HttpConfiguration OwinWebApiConfiguration(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();//开启属性路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new WebApiExceptionFilterAttribute());
            config.Filters.Add(new IdentityBasicAuthentication());
            return config;
        }
    }
}