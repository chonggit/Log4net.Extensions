using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Log4net.Extensions
{
    public static class Log4netExtensions
    {
        public static ILoggingBuilder AddLog4net(this ILoggingBuilder builder)
        {
            return builder.AddProvider(new Log4netProvider());
        }
    }
}
