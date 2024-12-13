public interface IEmailService
{
    void SendEmail(string user, string subject, string body);
}

public class EmailService : IEmailService
{
    public void SendEmail(string user, string subject, string body)
    {
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
        {
            throw new ArgumentException("User, subject, and body cannot be null or empty");
        }
        Console.WriteLine($"Sending email to {user}: {subject} - {body}");
    }
}
