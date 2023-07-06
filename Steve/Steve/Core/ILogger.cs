namespace Steve.Core
{
    public interface ILogger
    {
        internal void Submit(LogMessage logMessage);
        internal void Flush();

    }
}