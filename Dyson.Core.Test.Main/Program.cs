using System;
using System.Collections.Generic;
using Dyson.Core.DataBase.ORM.Test;
using Dyson.Core.DataBase.Entity;

/// <summary>
/// 用来方便测试的控制台应用程序
/// </summary>
namespace Dyson.Core.Test.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            test2();
        }

        public static void test1() 
        {
            firstTestORM UnitTest = new firstTestORM();
            List<AccountBase> datalist = UnitTest.MyQuery();
            foreach (AccountBase ac in datalist)
            {
                Console.WriteLine(ac.Name + ac.new_address + ac.new_phone);
            }
        }

        public static void test2()
        {
            firstTestORM UnitTest = new firstTestORM();
            string[] entityList = {
                "new_srv_site"
            };
            UnitTest.CreateEntitys(entityList);
        }
    }
}
