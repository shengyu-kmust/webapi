using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;
using System.Web.Http;
using webapi.Configs;

// 标识webapiOwin.Startup类为owin的启动类，也可写在AssemblyInfo.cs文件里
[assembly: OwinStartup(typeof(webapi.Owin.Startup))]

namespace webapi.Owin
{
    public class Startup
    {
        /// <summary>
        /// owin的http请求管道配置函数
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            #region 测试用
            //app.Run(context =>
            //{
            //    context.Response.Write("这是owin管道");
            //    return Task.FromResult(0);
            //});
            #endregion

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();//开启属性路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
    }
}
