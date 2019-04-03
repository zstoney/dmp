using System.Reflection;
using System.Configuration;
using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;


namespace dmp.Web
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        ///
        ///autofac注册方式
        ///1.单个实例注册
        ///2.扫描程序集注册
        ///3.配置文件注册xml或json
        ///
        ///注入方式
        ///1.构造函数注入
        ///2.属性注入 
        /// </summary>
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();


            //如果有Dal层的话，注册Dal层的组件
            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly dalAss = Assembly.Load("dmp.DAL");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(dalAss.GetTypes()).AsImplementedInterfaces().PropertiesAutowired();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serviceAss = Assembly.Load("dmp.BLL");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serviceAss.GetTypes()).AsImplementedInterfaces().PropertiesAutowired();


            #region 配置文件，注入适合大项目

            /*var config = new ConfigurationBuilder();
            //config.AddXmlFile(@"");
            config.AddJsonFile(HttpContext.Current.Server.MapPath("~/App_Start/auto.json"));
            var module = new ConfigurationModule(config.Build());*/

            #endregion

            /*var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(assemblies.ToArray());*/

            //使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//生成具体的实例(属性注入)
            var container = builder.Build();

            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}