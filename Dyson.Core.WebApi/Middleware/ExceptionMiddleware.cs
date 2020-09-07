using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dyson.Core.WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.WebUtilities;

namespace Dyson.Core.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var statusCodeFeature = new StatusCodePagesFeature();
            context.Features.Set<IStatusCodePagesFeature>(statusCodeFeature);

            await _next(context);

            if (context.Response.HasStarted
                || context.Response.StatusCode < 400
                || context.Response.StatusCode >= 600
                || context.Response.ContentLength.HasValue
                || !string.IsNullOrEmpty(context.Response.ContentType))
            {
                return;
            }

            string reason = ReasonPhrases.GetReasonPhrase(context.Response.StatusCode);
            BaseResultModel resModel = new BaseResultModel(code: context.Response.StatusCode, message: reason);

            string jsonString = JsonSerializer.Serialize(resModel);
            byte[] byteArray = Encoding.Default.GetBytes(jsonString);
            context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            await context.Response.Body.WriteAsync(byteArray);
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class MyExceptionMiddleware
    {
        public static IApplicationBuilder UseMyExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
