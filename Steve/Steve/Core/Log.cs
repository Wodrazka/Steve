namespace Steve.Core;

using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Log : ILog
{
    private readonly Action<LogMessage> _submit;
    private readonly LogMessage _message;
    private Stopwatch _stopwatch;

    internal Log(string name, Action<LogMessage> submit)
    {
        _message = new()
        {
            Name = name
        };
        _submit = submit;
        _stopwatch = new Stopwatch();
    }

    public void Submit()
    {
        if (_stopwatch.IsRunning)
        {
            _stopwatch.Stop();
        }

        if (_stopwatch.ElapsedMilliseconds > 0)
        {
            _message.Duration = _stopwatch.Elapsed.TotalSeconds;
        }

        _submit(_message);
    }

    public ILog WithCallerInfo([CallerMemberName] string methodName = "", [CallerFilePath] string filepath = "", [CallerLineNumber] int lineNumber = 0)
    {
        var callerInfo = new CallerInfo()
        {
            FilePath = filepath,
            LineNumber = lineNumber,
            Origin = methodName
        };
        _message.CallerInfo = callerInfo;
        return this;
    }

    public ILog WithException(Exception exception, bool withInnerException = false)
    {
        _message.Exception = exception;
        _message.WithInnerException = withInnerException;
        return this;
    }

    public ILog WithLogLevel(LogLevel level)
    {
        _message.Level = level;
        return this;
    }

    public ILog WithMessage(string message)
    {
        _message.Message = message;
        return this;
    }

    public ILog WithParameters(params (string, object)[] parameters)
    {
        _message.Parameters = parameters.ToDictionary(e => e.Item1, e => e.Item2);
        return this;
    }

    public ILog WithObject(object obj)
    {
        _message.AdditionalObject = obj;
        return this;
    }

    public ILog StartTimer()
    {
        _stopwatch = Stopwatch.StartNew();
        return this;
    }
}
