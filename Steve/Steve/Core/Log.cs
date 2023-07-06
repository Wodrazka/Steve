using System.Runtime.CompilerServices;

namespace Steve.Core
{
    public class Log : ILog
    {
        private readonly Action<LogMessage> _submit;
        internal LogMessage _message;
        internal Log(string name, Action<LogMessage> submit)
        {
            _message = new()
            {
                Name = name
            };
            _submit = submit;
        }

        public virtual void Submit()
        {
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
    }
}