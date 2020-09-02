using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson.Core.Autofac.Test
{
    public interface IMyService
    {
        public string ServiceString { set; get; }

        public string GetServiceString();

        public void SetServiceString(string value);
    }
}
