using System.Runtime.CompilerServices;

namespace Steve.Core
{
    public interface ILog
    {
        ILog WithMessage(string message);

        ILog WithParameters(params (string, object)[] parameters);

        ILog WithLogLevel(LogLevel level);

        ILog WithException(Exception exception, bool withInnerException = false);

        ILog WithCallerInfo([CallerMemberName] string methodName = "", [CallerFilePath] string filepath = "", [CallerLineNumber] int lineNumber = 0);

        ILog StartTimer();

        void Submit();
    }
}