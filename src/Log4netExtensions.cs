﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Log4net.Extensions
{
    public static class Log4netExtensions
    {
        public static IServiceCollection AddLog4net(this IServiceCollection services)
        {
            return AddLog4net(services, null);
        }
        
        public static IServiceCollection AddLog4net(this IServiceCollection services, Action<ILoggingBuilder> configure)
        {
            services.AddLogging(builder =>
            {
                builder.AddProvider(new Log4netProvider());
                if (configure != null)
                {
                    configure(builder);
                }
            });

            return services;
        }
    }
}
