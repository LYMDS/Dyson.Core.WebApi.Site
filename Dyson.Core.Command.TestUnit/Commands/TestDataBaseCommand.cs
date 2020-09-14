using System;
using System.Collections.Generic;
using System.Text;
using Dyson.Core.WebApi.Common;
using Dyson.Core.DataBase.Entity.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace Dyson.Core.Command.TestUnit.Commands
{
    public class TestDataBaseCommand
    {
        public TestDataBaseCommand(ILogger<TestDataBaseCommand> logger, IDysonDataBaseBuilder DbBuilder)
        {
            Logger = logger;
            DB = DbBuilder.InitDB();
        }

        public ILogger<TestDataBaseCommand> Logger { get; }

        public SqlSugarClient DB { get; }

        public string Add(ThemeBase theme)
        {
            DB.Insertable(theme).ExecuteCommand();
            return theme.ToString();
        }
    }
}