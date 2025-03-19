namespace Steve.Core;

using System.Runtime.CompilerServices;

public interface ILog
{
    public ILog WithMessage(string message);

    public ILog WithParameters(params (string, object)[] parameters);

    public ILog WithLogLevel(LogLevel level);

    public ILog WithException(Exception exception, bool withInnerException = false);

    public ILog WithCallerInfo([CallerMemberName] string methodName = "", [CallerFilePath] string filepath = "", [CallerLineNumber] int lineNumber = 0);

    public ILog WithObject(object obj);

    public ILog StartTimer();

    public void Submit();
}
