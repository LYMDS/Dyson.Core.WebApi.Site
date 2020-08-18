using System;
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
