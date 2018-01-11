using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac.Integration.WebApi;
using webapi.AutoFac;
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

            #region 写在前面的配置
            // 获取webapi的配置
            var config = WebApiConfig.OwinWebApiConfiguration(new HttpConfiguration());
            // 获取webapi的依赖注入容器
            var container = ContainerBuilerCommon.GetWebApiContainer();
            // 配置webapi的依赖注入
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion

            #region owin组件注册（要注意顺序）

            app.UseAutofacMiddleware(container);// 先注册autofac组件，需要依赖注入功能的组件在此后注册
            app.UseAutofacWebApi(config);//注册AutofacWebApi组件后再注册WebApi组件
            app.UseWebApi(config);
            #endregion
        }
    }
}
