
using Steve.Core;
using Steve.Logger;
using Steve.Logger.Misc;

ILogging<Program> logger = new Logging<Program>(LoggingLevel.Debug, new List<ILogger>()
{
    new ConsoleLogger(),
    new FileLogger(fileTimeSpan: FileTimeSpan.MONTH)
});

var timelog = logger.TimeLog("First timelog")
    .WithLogLevel(LogLevel.Debug)
    .WithMessage("the Sandbox")
    .WithCallerInfo();

logger.Log("First log")
    .WithMessage("First message")
    .Submit();

logger.Log("First error log")
    .WithMessage("Error while updating")
    .WithException(new Exception("Update failed"))
    .Submit();

logger.Log("log")
    .WithMessage("Update {newVersion} succesfull")
    .WithParameters(("newVersion", "1.0.0"))
    .WithLogLevel(LogLevel.Success)
    .WithCallerInfo()
    .Submit();

timelog.Submit();

