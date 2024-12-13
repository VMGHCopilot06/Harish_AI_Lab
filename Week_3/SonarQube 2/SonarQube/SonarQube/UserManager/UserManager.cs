public class UserManager : BaseController
{
    private readonly ILoggingService _loggingService;
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;
    private readonly INotificationService _notificationService;
    private readonly IAuditService _auditService;

    public UserManager(ILoggingService loggingService, IEmailService emailService, IUserRepository userRepository, INotificationService notificationService, IAuditService auditService)
    {
        _loggingService = loggingService;
        _emailService = emailService;
        _userRepository = userRepository;
        _notificationService = notificationService;
        _auditService = auditService;
    }

    public new void AddUser(string user)
    {
        base.AddUser(user);
        AddUserToRepository(user);
        _loggingService.LogMessage($"User {user} added");
        _emailService.SendEmail(user, "Welcome", $"Hello {user}, welcome to our system!");
        _notificationService.Notify(user, "You have been added to the system.");
        _auditService.RecordAction("AddUser", user);
    }

    private void AddUserToRepository(string user)
    {
        _userRepository.AddUser(user);
    }

    public new void RemoveUser(string user)
    {
        base.RemoveUser(user);
        RemoveUserFromRepository(user);
        _loggingService.LogMessage($"User {user} removed");
        _notificationService.Notify(user, "You have been removed from the system.");
        _auditService.RecordAction("RemoveUser", user);
    }

    private void RemoveUserFromRepository(string user)
    {
        _userRepository.RemoveUser(user);
    }
}
