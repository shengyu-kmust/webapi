using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using webapi.AutoFac.Modules;
using webapi.example;
using webapi.Entities;

namespace webapi.AutoFac
{
    public static class ContainerBuilerCommon
    {
        public static IContainer GetWebApiContainer()
        {
            var builder = new ContainerBuilder();
            // 注册当前程序集里的所有webapi控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            #region 注册modules
            builder.RegisterModule<LoggingModule>();
            #endregion

            #region 注册组件，如果项目比较大可以从此方法里单独移出
            //这里写注册组件的代码
            builder.RegisterType<DB>();
            #region 测试
            builder.RegisterType<Chinese>().As<People>();
            #endregion
            #endregion

            return builder.Build();
        }
    }
}