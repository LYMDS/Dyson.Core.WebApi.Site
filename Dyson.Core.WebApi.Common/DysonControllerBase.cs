using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Dyson.Core.WebApi.Common
{
    [ApiController]
    public abstract class DysonControllerBase : ControllerBase
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public DysonControllerBase(ILogger logger) : base()
        {
            this.LogManager = logger;
        }
        // 日志操作器
        public readonly ILogger LogManager;
    }
}
