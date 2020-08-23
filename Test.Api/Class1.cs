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
using Dyson.Core.DataBase.ORM;
using Dyson.Core.DataBase.ORM.Test;
using Dyson.Core.DataBase.Entity;
using Dyson.Core.Autofac.Test;

namespace Test.Api
{
    [ApiController]
    [Route("api/test")]
    public class Class1 : ControllerBase
    {
        public Logic LogicService { get; }
        public MyService MyService { get; }
        /// <summary>
        /// 构造函数
        /// 析出逻辑类
        /// </summary>
        /// <param name="logic"></param>
        public Class1(Logic logic, MyService myService) 
        {
            LogicService = logic;
            MyService = myService;
        }

        [HttpGet, Route("get")]
        public List<AccountBase> getAccount() 
        {
            firstTestORM UnitTest = new firstTestORM();
            List<AccountBase> datalist = UnitTest.MyQuery();
            return datalist;
        }

        [HttpGet, Route("getSite")]
        public new_srv_site get()
        {
            return LogicService.GetSite();
        }

        [HttpGet, Route("Test1")]
        public string Test1()
        {
            MyService.SetServiceString("测试AutoFac的服务析出");
            return MyService.GetServiceString();
        }
    }
}
