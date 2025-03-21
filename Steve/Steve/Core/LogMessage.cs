namespace Steve.Core;

using Newtonsoft.Json;
using Steve.Core.Converter;

public class LogMessage
{
    public string? Name { get; set; }

    public string? Message { get; set; }

    public Dictionary<string, object>? Parameters { get; set; }

    [JsonConverter(typeof(LogLevelConverter))]
    public LogLevel Level { get; set; } = LogLevel.Informative;

    public DateTime DateTime { get; set; } = DateTime.Now;

    public string? LoggedFrom { get; set; }

    public Exception? Exception { get; set; }

    public bool? WithInnerException { get; set; }

    public CallerInfo? CallerInfo { get; set; }

    public double? Duration { get; set; }

    public object? AdditionalObject { get; set; }

    [JsonIgnore]
    public static JsonSerializerSettings SerializerSettings => new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = Formatting.Indented,
        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
        TypeNameHandling = TypeNameHandling.Auto
    };

}
