using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Configuration.Xml;
using SqlSugar;

namespace Dyson.Core.WebApi.Common.PasswordManager
{
    public class ConfigHelper
    {
        public string ReadConfig(string key) 
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("db.config.json");
            IConfiguration Config = builder.Build();
            return Config.GetSection(key).Value;
        }

        public string GetConfigPath() 
        {
            return Directory.GetCurrentDirectory() + "\\db.config.xml";
        }
    }
}
