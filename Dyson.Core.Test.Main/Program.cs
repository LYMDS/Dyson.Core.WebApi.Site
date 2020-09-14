using System;
using System.Collections.Generic;
using Dyson.Core.WebApi.Common.PasswordManager;
using Autofac;
using System.Reflection;
using System.IO;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Dyson.Core.DataBase.Entity.Entitys;
using Dyson.Core.Test.Main.SqlSugarTools;

/// <summary>
/// 用来方便测试的控制台应用程序
/// </summary>
namespace Dyson.Core.Test.Main
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            CreateTableTest();
            //test3();
            //test4_init();
            //test4();
            // test5();
        }

        //public static void test1() 
        //{
        //    firstTestORM UnitTest = new firstTestORM();
        //    List<AccountBase> datalist = UnitTest.MyQuery();
        //    foreach (AccountBase ac in datalist)
        //    {
        //        Console.WriteLine(ac.Name + ac.new_address + ac.new_phone);
        //    }
        //}

        //public static void test2()
        //{
        //    firstTestORM UnitTest = new firstTestORM();
        //    string[] entityList = {
        //        "new_srv_site"
        //    };
        //    UnitTest.CreateEntitys(entityList);
        //}

        /// <summary>
        /// 测试RSA加密解密
        /// </summary>
        public static void test3()
        {
            RSAHelper RSA_Helper = new RSAHelper();
            string Key = "<RSAKeyValue><Modulus>71BFPveDqKvANe/T9/Zh5F/5vQ+3klVrurJGE103XEDVNn0OaL5FjmoRfCil2kzvfieRaWSjppXm8+qtZE6Mo3g8qkKFMqXV/mcKJhaf0V+o5AgXHcIm+G1tbvVJSA+1iQEgdwprPKcqwxQiZFDgZIMwocmB/E5Krp9RiQLfdjU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            string resEncrypt = RSA_Helper.Encrypt("Data Source=Test.db;", Key);
            Console.WriteLine("加密后");
            Console.WriteLine(resEncrypt);
        }

        ///// <summary>
        ///// 容器初始化
        ///// </summary>
        //public static void test4_init() 
        //{
        //    var builder = new ContainerBuilder();
        //    // builder.RegisterType<MyService>();
        //    // builder.RegisterType<MyService>().WithParameter(new TypedParameter(typeof(string), "注册时传参"));
        //    var MyAssembly = Assembly.Load("Dyson.Core.Autofac.Test");
        //    Console.WriteLine(MyAssembly);
        //    // var MyAssembly = Assembly.GetExecutingAssembly();
        //    builder.RegisterAssemblyTypes(MyAssembly).PublicOnly();
        //    Container = builder.Build();
        //}

        //public static void test4()
        //{
        //    using (var scope = Container.BeginLifetimeScope())
        //    {
        //        // var myService = scope.Resolve<MyService>();
        //        MyService myService = scope.Resolve<MyService>();
        //        myService.SetServiceString("这是我的第一个服务");
        //        Console.WriteLine(myService.GetServiceString());
        //    }
        //    Console.ReadKey();
        //}

        // 读取加密的数据库连接
        public static void test5()
        {
            ConfigHelper CFH = new ConfigHelper();
            Console.WriteLine(CFH.GetConfigPath());
            Console.WriteLine(CFH.ReadConfig("connstr"));
            Console.WriteLine(CFH.ReadConfig("publickey"));
        }

        public static void CreateTableTest() 
        {
            CreateDbTable cmd = new CreateDbTable();
            cmd.CreateTableByClass<ThemeBase>();
        }
    }
}