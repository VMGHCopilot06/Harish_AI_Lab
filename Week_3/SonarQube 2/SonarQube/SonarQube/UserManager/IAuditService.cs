public interface IAuditService
{
    void RecordAction(string action, string user);
}

public class AuditService : IAuditService
{
    public void RecordAction(string action, string user)
    {
        if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(user))
        {
            throw new ArgumentException("Action and user cannot be null or empty");
        }
        Console.WriteLine($"Recording action {action} for user {user}");
    }
}
