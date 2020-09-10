using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyson.Core.WebApi.Middleware
{
    /// <summary>
    /// 请求耗时计算中间件
    /// </summary>
    public class RequestDurationMiddleware
    {
        private DateTime _startTime;

        private readonly RequestDelegate _next;

        protected ILogger<RequestDurationMiddleware> Logger;

        public IConfiguration Configuration { get; private set; }

        public RequestDurationMiddleware(RequestDelegate next, ILogger<RequestDurationMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _startTime = DateTime.Now;
            
            await _next(context);

            double LongTimeRequest_Max = this.Configuration.GetSection("Logging:LongTimeRequest").Get<double>();
            double RequestTime = (DateTime.Now - _startTime).TotalMilliseconds;
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append(context.Request.Method);
            messageBuilder.Append(" ");
            messageBuilder.Append(context.Request.Scheme);
            messageBuilder.Append("://");
            messageBuilder.Append(context.Request.Host.Value);
            messageBuilder.Append(context.Request.Path.Value);
            messageBuilder.Append("\n\t执行耗时：");
            messageBuilder.Append(RequestTime.ToString());
            messageBuilder.Append("ms");
            
            if (RequestTime <= LongTimeRequest_Max)
            {
                string requestInfo = messageBuilder.ToString();
                Logger.LogInformation(requestInfo);
            }
            else // 超过慢请求相对值,使用Warn级别日志
            {
                string requestInfo = messageBuilder.ToString();
                Logger.LogWarning(requestInfo);
            }
        }
    }

    /// <summary>
    /// 请求耗时计算中间件扩展
    /// </summary>
    public static class MyRequestDurationMiddleware
    {
        public static IApplicationBuilder UseMyRequestDurationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestDurationMiddleware>();
        }
    }
}
