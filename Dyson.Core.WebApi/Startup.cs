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
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Dyson.Core.WebApi.ToolHelpers;
using Dyson.Core.WebApi.Middleware;
using Dyson.Core.WebApi.Filter;


namespace Dyson.Core.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(
                option => 
                {
                    option.Filters.Add<GlobalExceptionFilter>();
                    option.Filters.Add<GlobalControllerFormatFilter>();
                }
            ).AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMyRequestDurationMiddleware();

            app.UseMyExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// IOC����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ��ȡ����
            List<string> controller_dependencys = this.Configuration.GetSection("DependencyInjections:Controllers").Get<List<string>>();
            List<string> logic_dependencys = this.Configuration.GetSection("DependencyInjections:LogicClass").Get<List<string>>();
            DependencyInjectionHelper IOCHelper = new DependencyInjectionHelper(builder);
            // ע�������
            IOCHelper.AddAssemblysFromConfig(controller_dependencys);
            // ע���߼���
            IOCHelper.AddAssemblysFromConfig(logic_dependencys);
        }
    }
}
