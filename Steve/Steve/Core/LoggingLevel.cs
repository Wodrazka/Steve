namespace Steve.Core
{
    /// <summary>
    /// The Level of the Factory
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// Logs nothing
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Logs error, warning and success messages
        /// </summary>
        Error = 3,

        /// <summary>
        /// Logs all general Messages
        /// </summary>
        Informative = 4,

        /// <summary>
        /// Logs more details
        /// </summary>
        Verbose = 5,

        /// <summary>
        /// Logs everything
        /// </summary>
        Debug = 6,
    }
}