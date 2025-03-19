namespace Steve.Core;

using Newtonsoft.Json;

public class Logging<T>(LoggingLevel loggingLevel, ILogger[] loggers) : ILogging<T>
{
    [JsonProperty]
    private readonly ILogger[] _loggers = loggers;

    private readonly LoggingLevel _loggingLevel = loggingLevel;

    internal void Submit(LogMessage message)
    {
        if ((int)message.Level > (int)_loggingLevel)
        {
            return;
        }

        message.LoggedFrom = typeof(T).ToString();

        foreach (var logger in _loggers)
        {
            logger.Submit(message);
        }
    }

    public ILog Log(string name)
    {
        var log = new Log(name, Submit);
        return log;
    }
}
