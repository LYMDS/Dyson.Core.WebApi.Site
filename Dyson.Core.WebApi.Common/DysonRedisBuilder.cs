using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Dyson.Core.WebApi.Common
{
    public class DysonRedisBuilder : IDysonRedisBuilder
    {
        public IConfiguration Config { get; }
        public ILogger<DysonRedisBuilder> Logger { get; }

        public DysonRedisBuilder(ILogger<DysonRedisBuilder> logger, IConfiguration config)
        {
            Logger = logger;
            Config = config;
        }

        public IDatabase InitRDB()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Config.GetSection("redis").Value);
            IDatabase rdb = redis.GetDatabase();
            return rdb;
        }

    }
}
