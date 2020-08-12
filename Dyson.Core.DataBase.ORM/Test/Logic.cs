using System;
using System.Collections.Generic;
using System.Text;
using Dyson.Core.WebApi.Common;
using Microsoft.Extensions.Logging;
using Dyson.Core.DataBase.Entity;

namespace Dyson.Core.DataBase.ORM.Test
{
    public class Logic : DysonCommandBase
    {
        public Logic(ILogger<Logic> logger) : base()
        {
            this.LogManager = logger;
        }

        public new_srv_site GetSite() 
        {
            List<new_srv_site> siteList = db.Queryable<new_srv_site>().Where(it => it.new_srv_siteId == new Guid("1F8ABF10-6E60-E511-80BC-00155D09C90D")).ToList();
            this.LogManager.LogInformation("随便打印点东西");
            if (siteList.Count == 1)
            {
                this.LogManager.LogInformation(siteList[0].new_name);
                return siteList[0];
            }
            else 
            {
                return null;
            }
        }
    }
}
