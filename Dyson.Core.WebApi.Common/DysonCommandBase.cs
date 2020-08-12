using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using SqlSugar;

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
            this.LogManager = null;
        }

        // 日志操作器
        protected ILogger LogManager { set; get; }
        // 数据库操作器
        public SqlSugarClient db { 
            get 
            { 
                return InitDB();
            } 
        }

        private SqlSugarClient InitDB() 
        {
            // 创建数据库连接
            var db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = "server=.;uid=sa;pwd=collecting123;database=CSRZIC_MSCRM",
                    DbType = DbType.SqlServer,// 设置数据库类型
                    IsAutoCloseConnection = true,// 自动释放数据务，如果存在事务，在事务结束后释放
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
