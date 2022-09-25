using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Log4net.Extensions
{
    public static class Log4netExtensions
    {
        public static IServiceCollection AddLog4net(this IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddProvider(new Log4netProvider());
            });

            return services;
        }
    }
}
