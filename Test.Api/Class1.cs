using System;
using Dyson.Core.WebApi.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dyson.Core.DataBase.ORM.Test;
using Dyson.Core.DB.Entity;

namespace Test.Api
{
    [ApiController]
    [Route("api/test")]
    public class Class1 : ControllerBase
    {
        // public Class1(IConfiguration configuration, ILogger logger) : base(configuration, logger) { }

        [HttpGet, Route("get")]
        public List<AccountBase> getAccount() 
        {
            firstTestORM UnitTest = new firstTestORM();
            List<AccountBase> datalist = UnitTest.MyQuery();
            return datalist;
        }
    }
}
