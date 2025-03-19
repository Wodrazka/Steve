namespace Steve.Logger;

using Newtonsoft.Json;
using Steve.Core;
using Steve.Logger.Misc;

public class FileLogger : ILogger
{
    [JsonProperty]
    public string Basepath { get; set; } = "";

    [JsonProperty]
    [JsonConverter(typeof(FileTimeSpanConverter))]
    public FileTimeSpan FileTimeSpan { get; set; } = FileTimeSpan.INFINITY;

    [JsonProperty]
    public int LogThreshold { get; set; } = 1;

    private readonly List<LogMessage> _messages;

    private readonly object _messagesLock;

    public FileLogger(string basepath = "", int logThreshold = 1, FileTimeSpan fileTimeSpan = FileTimeSpan.INFINITY)
    {
        Basepath = basepath;
        LogThreshold = logThreshold;
        FileTimeSpan = fileTimeSpan;

        _messagesLock = new object();

        var filepath = Path.Combine(Basepath ?? Environment.CurrentDirectory, $"log_{FileTimeSpan.GetDateTimeString()}.json");

        if (File.Exists(filepath))
        {
            _messages = JsonConvert.DeserializeObject<List<LogMessage>>(File.ReadAllText(filepath), LogMessage.SerializerSettings) ?? [];
        }
        else
        {
            _messages = [];
        }
    }

    void ILogger.Flush() => InternalFlush();

    void ILogger.Submit(LogMessage logMessage)
    {
        lock (_messagesLock)
        {
            _messages.Add(logMessage);
        }

        lock (_messagesLock)
        {
            if (_messages.Count >= LogThreshold)
            {
                InternalFlush();
            }
        }
    }

    private void InternalFlush()
    {
        lock (_messagesLock)
        {
            var filepath = Path.Combine(Basepath ?? Environment.CurrentDirectory, $"log_{FileTimeSpan.GetDateTimeString()}.json");

            //TODO: logging without load and save all log messages
            File.WriteAllText(filepath, JsonConvert.SerializeObject(_messages, LogMessage.SerializerSettings));
        }
    }
}
