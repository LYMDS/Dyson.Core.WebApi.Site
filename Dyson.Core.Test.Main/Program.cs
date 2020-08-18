<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using Dyson.Core.DataBase.ORM.Test;
using Dyson.Core.DataBase.Entity;
using Autofac;
using Dyson.Core.Autofac.Test;

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
            test4_init();
            test4();
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















        public static void test4_init() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyService>(); //.WithParameter(new TypedParameter(typeof(string), "注册时传参"));
            Container = builder.Build();
        }

        public static void test4()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                // var myService = scope.Resolve<MyService>();
                MyService myService = scope.Resolve<MyService>();
                myService.SetServiceString("这是我的第一个服务");
                Console.WriteLine(myService.GetServiceString());
                Console.ReadKey();
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using Dyson.Core.DataBase.ORM.Test;
using Dyson.Core.DataBase.Entity;
using Dyson.Core.WebApi.Common.PasswordManager;

/// <summary>
/// 用来方便测试的控制台应用程序
/// </summary>
namespace Dyson.Core.Test.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            test3();
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

        /// <summary>
        /// 测试RSA加密解密
        /// </summary>
        public static void test3()
        {
            RSAHelper RSA_Helper = new RSAHelper();
            RSAKey Keys = RSA_Helper.GenerateRSAKey(); 
            string resEncrypt = RSA_Helper.Encrypt("server=.;uid=sa;pwd=collecting123;database=CSRZIC_MSCRM", Keys.PublicKey);
            Console.WriteLine("加密后");
            Console.WriteLine(resEncrypt);
            Console.WriteLine("解密后");
            Console.WriteLine(RSA_Helper.Decrypt(resEncrypt, Keys.PrivateKey));
        }
    }
}
>>>>>>> 5023cc5d7d4485433a35eff69f99c6ffefbb73a8
