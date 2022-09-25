using log4net;
using log4net.Config;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Log4net.Extensions
{
    public class Log4netProvider : ILoggerProvider
    {
        const string CONFIG_FILE = "log4net.xml";

        public Log4netProvider()
        {
            if (File.Exists(CONFIG_FILE) == false)
            {
                using Stream stream = typeof(Log4netProvider).Assembly.GetManifestResourceStream("Log4net.Extensions.log4net.xml");
                using FileStream fileStream = new(CONFIG_FILE, FileMode.Create);
                stream.CopyTo(fileStream);
                fileStream.Flush();
            }
            XmlConfigurator.ConfigureAndWatch(new FileInfo(CONFIG_FILE));
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Log4netLogger(LogManager.GetLogger(categoryName));
        }

        public void Dispose()
        {
        }
    }
}
