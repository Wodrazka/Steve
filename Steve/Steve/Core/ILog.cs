namespace Steve.Core;

using System.Runtime.CompilerServices;

public interface ILog
{
    ILog WithMessage(string message);

    ILog WithParameters(params (string, object)[] parameters);

    ILog WithLogLevel(LogLevel level);

    ILog WithException(Exception exception, bool withInnerException = false);

    ILog WithCallerInfo([CallerMemberName] string methodName = "", [CallerFilePath] string filepath = "", [CallerLineNumber] int lineNumber = 0);

    ILog WithObject(object obj);

    ILog StartTimer();

    void Submit();
}
