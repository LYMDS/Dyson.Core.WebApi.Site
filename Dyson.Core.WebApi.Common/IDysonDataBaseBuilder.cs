using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace Dyson.Core.WebApi.Common
{
    public interface IDysonDataBaseBuilder
    {
        IConfiguration Config { get; }
        ILogger<DysonDataBaseBuilder> Logger { get; }

        SqlSugarClient InitDB();
    }
}