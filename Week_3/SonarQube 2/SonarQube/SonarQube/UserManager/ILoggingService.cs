public interface ILoggingService
{
    void LogMessage(string message);
}

public class LoggingService : ILoggingService
{
    private readonly ILogger _logger;

    public LoggingService(ILogger logger)
    {
        _logger = logger;
    }

    public void LogMessage(string message)
    {
        _logger.LogMessage(message);
    }
}
