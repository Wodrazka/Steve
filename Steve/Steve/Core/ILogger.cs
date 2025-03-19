namespace Steve.Core;

public interface ILogger
{
    public void Submit(LogMessage logMessage);
    public void Flush();

}
