===============================================================================
项目结构
--Configs
--Owin




===============================================================================
用到的技术
Owin
	实现webapi应用和服务器的解耦
Autofac
	依赖注入，面向接口编程
Log4net
	日志
EF
	数据库访问层，用code first





===============================================================================
nuget包及dll介绍
webapi相关的包
--包Microsoft.AspNet.WebApi.Core 
	packages里无dll，依赖于Microsoft.AspNet.WebApi.WebHost，
	webapi项目的必需包，安装后会下载Microsoft.AspNet.WebApi.WebHost和Microsoft.AspNet.WebApi.Core
--包Microsoft.AspNet.WebApi.WebHost
	在iis环境下用webapi时的必需包
	含：System.Web.Http.WebHost.dll，依赖于包Microsoft.AspNet.WebApi.Core
--包Microsoft.AspNet.WebApi.Core
	webapi技术的核心包
	含：System.Web.Http.dll,依赖于包Microsoft.AspNet.WebApi.Client
--包Microsoft.AspNet.WebApi.Client
	webapi核心包所依赖的类库
	含：System.Net.Http.Formatting.dll

owin相关
--包Owin
	owin的接口规范
--包Microsoft.Owin
	microsoft对owin规范的扩展
--包Microsoft.Owin.Host.SystemWeb
	owin以iis为宿主时的必备包，负责拦截iis请求到owin管道，如果删除此dll，则会返回到iis asp.net request pipeline里
	依赖：Microsoft.Owin和Owin包
owin host相关
--包Microsoft.Owin.SelfHost
	owin自宿主必备包，写自宿主程序时必需引用 
	依赖Microsoft.Owin.Hosting，Owin，Microsoft.Owin.Diagnostics，Microsoft.Owin.Host.HttpListener，Microsoft.Owin
--包Microsoft.Owin.Hosting
	Provides default infrastructure types for hosting and running OWIN-based applications.
--包Microsoft.Owin.Diagnostics
	Provides middleware components to assist in developing OWIN-based applications.
--包Microsoft.Owin.Host.HttpListener
	OWIN server built on the .NET Framework's HttpListener class. Currently the default server used for self-hosting.

webapi owin相关
--包Microsoft.AspNet.WebApi.Owin
	含：System.Web.Http.Owin.dll
--包Microsoft.AspNet.WebApi.OwinSelfHost
	无dll文件，依赖Microsoft.AspNet.WebApi.Owin ，Microsoft.Owin.Host.HttpListener，Microsoft.Owin.Hosting