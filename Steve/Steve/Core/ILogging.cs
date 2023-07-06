namespace Steve.Core
{
    public interface ILogging<T>
    {

        ILog Log(string name);

        ILog TimeLog(string name);

    }
}