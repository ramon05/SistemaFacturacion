using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Config
{
    public static class SerilogConfig
    {
        public static IServiceCollection configSerilog(this IServiceCollection services)
        {
            var _loggerConfig = new LoggerConfiguration().Enrich.FromLogContext();
            _loggerConfig
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Warning).WriteTo.File("logs/warnigs.txt"))
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Error).WriteTo.File("logs/errors.txt"))
                .WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Fatal).WriteTo.File("logs/fatals.txt"));

            Log.Logger = _loggerConfig.CreateLogger();
            services.AddSingleton(Log.Logger);

            return services;
        }
    }
}
