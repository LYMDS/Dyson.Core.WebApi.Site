using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Dyson.Core.DB.Entity;

namespace Dyson.Core.DataBase.ORM.Test
{
    public class firstTestORM
    {
        public firstTestORM()
        {
            this.db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = "server=.;uid=sa;pwd=collecting123;database=CSRZIC_MSCRM",
                    DbType = DbType.SqlServer,// 设置数据库类型
                    IsAutoCloseConnection = true,// 自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
                });

            // Aop执行切面
            this.db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        public SqlSugarClient db;

        public void CreateEntitys() 
        {
            // 生成实体
            // db.DbFirst.CreateClassFile("c:\\Demo\\1", 命名空间);
            this.db.DbFirst.Where("AccountBase").CreateClassFile("D:\\C#工作空间", "Dyson.Core.DB.Entity");
        }

        public List<AccountBase> MyQuery() 
        {
            return this.db.Queryable<AccountBase>().ToList();
        }

    }
}
