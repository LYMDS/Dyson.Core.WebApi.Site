﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Dyson.Core.Autofac.Test
{
    public class MyService
    {
        public MyService() { }
        public MyService(string InitString) 
        {
            this.SetServiceString(InitString);
        }
        public MyService(string InitString, int num) 
        {
            this.SetServiceString(InitString + num.ToString());
        }

        public string ServiceString { set; get; }

        public string GetServiceString() 
        {
            return this.ServiceString;
        }

        public void SetServiceString(string value) 
        {
            this.ServiceString = value;
        }
    }
}