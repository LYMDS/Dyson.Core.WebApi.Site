using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Dyson.Core.WebApi.ToolHelpers;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;

namespace Dyson.Core.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers().AddControllersAsServices();
            // IMvcBuilder mvcBuilder = services.AddControllers().AddControllersAsServices();
            // 注入控制器程序集
            //List<string> controller_dependencys = this.Configuration.GetSection("DependencyInjections:Controllers").Get<List<string>>();
            //if (controller_dependencys != null && controller_dependencys.Count > 0)
            //{
            //    foreach (string i in controller_dependencys)
            //    {
            //        DependencyInjectionHelper.AddAssemblyFromDllToMvcBuilder(mvcBuilder, i);
            //    }
            //}
            //services.AddMvc();
            //services.AddOptions();
            //services.AddMvc().AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            // app.UseMvc();
            // 注册中间件
            //app.Use(async (context, next) =>
            //{
            //   this.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        /// <summary>
        /// 依赖注入的入口函数
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Console.WriteLine(AppContext.BaseDirectory);
            var MyAssembly = Assembly.LoadFile(AppContext.BaseDirectory + "Dyson.Core.Autofac.Test.dll");
            builder.RegisterAssemblyTypes(MyAssembly).PublicOnly();
            var MyAssembly2 = Assembly.LoadFile(AppContext.BaseDirectory + "Dyson.Core.DataBase.ORM.dll");
            builder.RegisterAssemblyTypes(MyAssembly2).PublicOnly();
            var MyAssembly3 = Assembly.LoadFile(AppContext.BaseDirectory + "Test.Api.dll");
            builder.RegisterAssemblyTypes(MyAssembly3).PublicOnly();
            Console.WriteLine("成功注入程序集：" + MyAssembly.ToString());
            Console.WriteLine("成功注入程序集：" + MyAssembly2.ToString());
            Console.WriteLine("成功注入程序集：" + MyAssembly3.ToString());
            // builder.RegisterType<>();
            // builder.Build();
        }
    }
}
