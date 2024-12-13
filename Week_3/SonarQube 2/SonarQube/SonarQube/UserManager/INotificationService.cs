public interface INotificationService
{
    void Notify(string user, string message);
}

public class NotificationService : INotificationService
{
    public void Notify(string user, string message)
    {
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("User and message cannot be null or empty");
        }
        Console.WriteLine($"Notifying {user}: {message}");
    }
}
