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
        public DysonControllerBase(IConfiguration configuration, ILogger logger) : base()
        {
            this.Configuration = configuration;
            this.LogManager = logger;
        }
        public IConfiguration Configuration { get; }
        public readonly ILogger LogManager;
    }
}
