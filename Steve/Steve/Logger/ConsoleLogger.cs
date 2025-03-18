using System.Text;
using Steve.Core;
using Steve.Core.Extensions;

namespace Steve.Logger
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {

        }

        void ILogger.Flush()
        {

        }

        void ILogger.Submit(LogMessage logMessage)
        {
            StringBuilder @string = new StringBuilder(logMessage.Message);

            if (logMessage.Parameters != null)
            {
                if (logMessage.Parameters.Count == logMessage.Parameters.Count)
                {
                    foreach (var parameter in logMessage.Parameters)
                    {
                        @string.Replace($"{{{parameter.Key}}}", $"{parameter.Value}");
                    }
                }
            }

            if (logMessage.Duration != null)
                @string.Append($" took {logMessage.Duration} sec.");

            Console.ForegroundColor = logMessage.Level.GetConsoleColor();
            Console.WriteLine($"[{logMessage.DateTime:yyyy-MM-dd hh:mm:ss}] {Enum.GetName(logMessage.Level),-11}: {@string}");
            Console.ResetColor();
        }
    }
}
