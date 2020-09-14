using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;
using Dyson.Core.WebApi.Common.PasswordManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dyson.Core.WebApi.Common
{
    public class DysonDataBaseBuilder : IDysonDataBaseBuilder
    {
        public IConfiguration Config { get; }
        public ILogger<DysonDataBaseBuilder> Logger { get; }

        public DysonDataBaseBuilder(ILogger<DysonDataBaseBuilder> logger, IConfiguration config)
        {
            Logger = logger;
            Config = config;
        }

        public SqlSugarClient InitDB()
        {
            string connStr = Config.GetSection("connstr").Value;
            string Key = Config.GetSection("privatekey").Value;
            RSAHelper RSA_Helper = new RSAHelper();
            connStr = RSA_Helper.Decrypt(connStr, Key);
            // 创建数据库连接
            var db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = connStr,
                    DbType = DbType.Sqlite, // 设置数据库类型
                    IsAutoCloseConnection = true, // 自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
                });

            // 执行SQL时的切面AOP
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string debugSQL = sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));
                Logger.LogDebug(debugSQL);
            };
            return db;
        }
    }
}
