using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dyson.Core.WebApi.Filter
{
    public class GlobalControllerFormatFilter : Attribute, IResultFilter
    {
        protected ILogger<GlobalControllerFormatFilter> Logger;

        public GlobalControllerFormatFilter(ILogger<GlobalControllerFormatFilter> logger) 
        {
            Logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

            Logger.LogInformation("我是全局过滤器GlobalControllerFormatFilter after");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Logger.LogInformation("我是全局过滤器GlobalControllerFormatFilter before");
        }
    }
}
