using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Log4net.Extensions
{
    internal class Log4netLogger : ILogger
    {
        private static readonly Type ThisDeclaringType = typeof(Log4netLogger);

        private readonly ILog _log;

        public Log4netLogger(ILog log)
        {
            _log = log;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return default;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => _log.IsDebugEnabled,
                LogLevel.Debug => _log.IsDebugEnabled,
                LogLevel.Information => _log.IsInfoEnabled,
                LogLevel.Warning => _log.IsWarnEnabled,
                LogLevel.Error => _log.IsErrorEnabled,
                LogLevel.Critical => _log.Logger.IsEnabledFor(Level.Critical),
                _ => false,
            };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                _log.Logger.Log(ThisDeclaringType, ConvertLogLevel(logLevel), formatter(state, exception), exception);
            }
        }

        private static Level ConvertLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => Level.Trace,
                LogLevel.Debug => Level.Debug,
                LogLevel.Information => Level.Info,
                LogLevel.Warning => Level.Warn,
                LogLevel.Error => Level.Error,
                LogLevel.Critical => Level.Critical,
                _ => Level.Off,
            };
        }
    }
}
