using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;
using SqlSugar;
using System.IO;
using Dyson.Core.WebApi.Common.PasswordManager;

namespace Dyson.Core.WebApi.Common
{
    /// <summary>
    /// Dyson命令基类
    /// </summary>
    public class DysonCommandBase
    {
        /// <summary>
        /// 初始化函数
        /// </summary>
        public DysonCommandBase() 
        {
            // 日志操作器初始化为空
            this.LogManager = null;
            // 读取配置接口初始化
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory).AddXmlFile("db.config.json");
            this.Config = builder.Build();
        }

        // 读取配置接口
        protected IConfiguration Config { set; get; }
        // 日志操作器
        protected ILogger LogManager { set; get; }
        // 数据库操作器
        public SqlSugarClient db 
        { 
            get 
            { 
                return InitDB();
            } 
        }

        private SqlSugarClient InitDB() 
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
                    DbType = DbType.SqlServer, // 设置数据库类型
                    IsAutoCloseConnection = true, // 自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
                });

            // 执行SQL时的切面AOP
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                // 如果外部Command不使用日志
                if (this.LogManager != null) 
                {
                    string debugSQL = sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));
                    this.LogManager.LogDebug(debugSQL); 
                }
            };
            return db;
        }
    }
}
