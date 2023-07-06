using Newtonsoft.Json;

namespace Steve.Core
{
    public class Logging<T> : ILogging<T>
    {
        [JsonProperty]
        private List<ILogger> _loggers;

        private LoggingLevel _loggingLevel = LoggingLevel.Error;

        public Logging(LoggingLevel loggingLevel, List<ILogger> loggers)
        {
            _loggingLevel = loggingLevel;
            _loggers = loggers;
        }

        internal void Submit(LogMessage message)
        {
            if ((int)message.Level > (int)_loggingLevel)
                return;

            message.LoggedFrom = typeof(T).ToString();

            foreach (var logger in _loggers)
                logger.Submit(message);
        }

        public ILog Log(string name)
        {
            var log = new Log(name, Submit);
            return log;
        }
    }
}