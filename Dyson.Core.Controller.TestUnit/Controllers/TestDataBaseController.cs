using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Dyson.Core.DataBase.Entity.Entitys;
using Dyson.Core.Command.TestUnit.Commands;

namespace Dyson.Core.Controller.TestUnit.Controllers
{
    [ApiController, Route("api/TestDataBase")]
    public class TestDataBaseController : ControllerBase
    {
        public TestDataBaseCommand TestDataBaseCommand { set; get; }

        public TestDataBaseController(TestDataBaseCommand testDataBaseCommand)
        {
            TestDataBaseCommand = testDataBaseCommand;
        }

        [HttpGet, Route("Test")]
        public string Test()
        {
            return "TestDataBase控制器注入成功";
        }

        [HttpGet, Route("Add")]
        public string Add(ThemeBase theme)
        {
            return TestDataBaseCommand.Add(theme);
        }

        [HttpGet, Route("GetRedisValue")]
        public string GetRedisValue(string key) 
        {
            return TestDataBaseCommand.GetRedisValue(key);
        }

        [HttpGet, Route("WriteRedisValue")]
        public bool WriteRedisValue(string key, string value)
        {
            return TestDataBaseCommand.WriteRedisValue(key, value); 
        }

        [HttpGet, Route("DeleteRedisValue")]
        public bool DeleteRedisValue(string key) 
        {
            return TestDataBaseCommand.DeleteRedisValue(key);
        }
    }
}
