using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dyson.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dyson.Core.WebApi.Filter
{
    /// <summary>
    /// 内部异常专用过滤器
    /// </summary>
    public class GlobalExceptionFilter : Attribute, IExceptionFilter
    {
        protected ILogger<GlobalExceptionFilter> Logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            Logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            Logger.LogError(context.Exception, context.Exception.Message);
            context.Result = new ObjectResult(new BaseResultModel(code: 500, message: context.Exception.Message));
        }
    }
}
