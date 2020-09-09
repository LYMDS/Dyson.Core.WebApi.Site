using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dyson.Core.WebApi.Models;

namespace Dyson.Core.WebApi.Filter
{
    /// <summary>
    /// WebApi响应格式化过滤器
    /// </summary>
    public class GlobalControllerFormatFilter : Attribute, IResultFilter
    {
        protected ILogger<GlobalControllerFormatFilter> Logger;

        public GlobalControllerFormatFilter(ILogger<GlobalControllerFormatFilter> logger) 
        {
            Logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context) { }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            if (objectResult != null)
            {
                Logger.LogWarning(objectResult.StatusCode.ToString());
                context.Result = new OkObjectResult(new BaseResultModel(code: 200, data: objectResult.Value));
            }
            else
            {
                context.Result = new OkObjectResult(new BaseResultModel(code: 200, message: "Void Function", data: objectResult));
            }
        }
    }
}
