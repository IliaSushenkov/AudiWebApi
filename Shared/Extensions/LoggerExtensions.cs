using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Filters;
using ILogger = Serilog.ILogger;

namespace Audi.Shared.Extentions
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddSerilogLogger(
        this ILoggingBuilder loggingBuilder,
        IEnumerable<string> excludeEndpoints = null)
        {
            ILogger serilogLogger = new LoggerConfiguration()
            .Filter.ByExcluding(
                    Matching.WithProperty<string>("RequestPath", v => (excludeEndpoints ?? Array.Empty<string>())
                        .Any(excludeEndpoint => excludeEndpoint.Contains(v, StringComparison.OrdinalIgnoreCase))))
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {CorrelationId} {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            loggingBuilder
                .ClearProviders()
                .AddSerilog(serilogLogger);

            return loggingBuilder;
        }
    }
}
