using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dyson.Core.WebApi.Controllers
{
    [ApiController]
    [Route("Meta")]
    public class MetaController : ControllerBase
    {
        public MetaController(IConfiguration configuration, ILogger<MetaController> logger) 
        {
            Configuration = configuration;
            LogManager = logger;
        }

        private readonly ILogger LogManager;

        public IConfiguration Configuration { get; }

        [HttpGet]
        [Route("GetVersion")]
        public string GetVersion() 
        {
            LogManager.LogInformation(this.Request.Host.Host + this.Request.Host.Port.ToString());
            LogManager.LogInformation("查看版本");
            return "Dyson.Core.WebApi.Site " + this.Configuration.GetValue<string>("Version");
        }
    }
}
