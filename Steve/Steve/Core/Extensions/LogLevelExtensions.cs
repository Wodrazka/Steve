using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steve.Core.Extensions
{
    internal static class LogLevelExtensions
    {
        public static ConsoleColor GetConsoleColor(this LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    return ConsoleColor.Cyan;
                case LogLevel.Verbose:
                    return ConsoleColor.Gray;
                case LogLevel.Informative:
                    return ConsoleColor.White;
                case LogLevel.Error:
                    return ConsoleColor.Red;
                case LogLevel.Warning:
                    return ConsoleColor.Yellow;
                case LogLevel.Success:
                    return ConsoleColor.Green;
                default:
                    Console.ResetColor();
                    return Console.ForegroundColor;
            }
        }
    }
}
