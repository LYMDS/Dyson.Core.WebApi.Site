using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dyson.Core.WebApi.Models
{
    public class BaseResultModel
    {
        public BaseResultModel(int? code = null, string message = null,
            object data = null)
        {
            this.ErrorCode = code;
            this.Data = data;
            this.Message = message;
        }
        public int? ErrorCode { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

    }
}
