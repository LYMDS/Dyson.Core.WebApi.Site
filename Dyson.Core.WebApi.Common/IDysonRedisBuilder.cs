using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Dyson.Core.WebApi.Common
{
    public interface IDysonRedisBuilder
    {
        IConfiguration Config { get; }
        ILogger<DysonRedisBuilder> Logger { get; }

        IDatabase InitRDB();
    }
}