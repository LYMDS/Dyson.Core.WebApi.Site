using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Dyson.Core.DataBase.Entity.Entitys
{
    public class ThemeBase
    {
        [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
        public Guid ThemeId { set; get; }

        public string message { set; get; }

        public override string ToString()
        {
            return ThemeId.ToString() + message;
        }
    }
}
