using System;
using System.Collections.Generic;
using System.Text;
using Dyson.Core.WebApi.Common;
using Dyson.Core.DataBase.Entity.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;
using StackExchange.Redis;

namespace Dyson.Core.Command.TestUnit.Commands
{
    public class TestDataBaseCommand
    {
        public TestDataBaseCommand(ILogger<TestDataBaseCommand> logger, IDysonDataBaseBuilder DbBuilder, IDysonRedisBuilder RedisDbBuilder)
        {
            Logger = logger;
            DB = DbBuilder.InitDB();
            RDB = RedisDbBuilder.InitRDB();
        }

        public ILogger<TestDataBaseCommand> Logger { get; }

        public SqlSugarClient DB { get; }

        public IDatabase RDB { get; }

        
        public string Add(ThemeBase theme)
        {
            DB.Insertable(theme).ExecuteCommand();
            return theme.ToString();
        }

        /// <summary>
        /// 根据Key获取RedisValue
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetRedisValue(string key) 
        {
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("Key不能为空！");
            return RDB.StringGet(key).ToString();
        }

        /// <summary>
        /// 写入Redis数据库
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool WriteRedisValue(string key, string value) 
        {
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("Key不能为空！");
            return RDB.StringSet(key, value);
        }

        /// <summary>
        /// 删除Redis记录
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool DeleteRedisValue(string key) 
        {
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("Key不能为空！");
            return RDB.KeyDelete(key);
        }
    }
}