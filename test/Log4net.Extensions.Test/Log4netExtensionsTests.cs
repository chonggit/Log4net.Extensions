using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Log4net.Extensions.Test
{
    [TestClass]
    public class Log4netExtensionsTests
    {
        [TestMethod]
        public void LogTest()
        {
            if (File.Exists("log4net.xml"))
            {
                File.Delete("log4net.xml");
            }
            var services = new ServiceCollection();
            services.AddLog4net(builder => { builder.SetMinimumLevel(LogLevel.Trace); });

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILoggerFactory factory = serviceProvider.GetRequiredService<ILoggerFactory>();
            ILogger logger = factory.CreateLogger<Log4netExtensionsTests>();

            Assert.IsNotNull(logger);

            logger.LogTrace("trace");
            logger.LogDebug("debug");
            logger.LogInformation("information");
            logger.LogWarning("warning");
            logger.LogError(new ApplicationException("ApplicationException"), "error");
            logger.LogCritical(new ApplicationException("ApplicationException"), "critical");
        }
    }
}