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
using Dyson.Core.DataBase.ORM;
using Dyson.Core.DataBase.ORM.Test;

namespace Dyson.Core.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddControllers();
            // 注入控制器程序集
            List<string> controller_dependencys = this.Configuration.GetSection("DependencyInjections:Controllers").Get<List<string>>();
            if (controller_dependencys != null && controller_dependencys.Count > 0)
            {
                foreach (string i in controller_dependencys)
                {
                    DependencyInjectionHelper.AddAssemblyFromDllToMvcBuilder(mvcBuilder, i);
                }
            }
            // 注入逻辑层程序集
            List<string> logic_dependencys = this.Configuration.GetSection("DependencyInjections:LogicClass").Get<List<string>>();
            if (controller_dependencys != null && controller_dependencys.Count > 0)
            {
                foreach (string i in logic_dependencys)
                {
                    DependencyInjectionHelper.AddAssemblyFromDll(i);
                }
            }
            // 注入一个逻辑层
            services.AddScoped<Logic>();
            services.AddScoped(Type.GetType("Logic"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //   this.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
