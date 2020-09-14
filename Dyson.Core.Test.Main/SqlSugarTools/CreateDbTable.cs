using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Dyson.Core.Test.Main.SqlSugarTools
{
    public class CreateDbTable
    {
        public SqlSugarClient DB { set; get; }

        public CreateDbTable()
        {
            string connStr = "Data Source=Test.db;";
            // 创建数据库连接
            this.DB = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = connStr,
                    DbType = DbType.Sqlite, // 设置数据库类型
                    IsAutoCloseConnection = true, // 自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
                });
        }

        public void CreateTableByClass<T>() 
        {
            DB.CodeFirst.InitTables(typeof(T));
        }
    }
}
