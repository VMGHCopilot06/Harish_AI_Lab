public interface ILogger
{
    void LogMessage(string message);
}

public class FileLogger : ILogger
{
    public void LogMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("Message cannot be null or empty");
        }
        File.AppendAllText("log.txt", message + Environment.NewLine);
    }
}
