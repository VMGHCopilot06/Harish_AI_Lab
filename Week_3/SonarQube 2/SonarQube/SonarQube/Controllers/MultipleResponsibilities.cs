using System;
using System.Collections.Generic;
using System.IO;

namespace SonarQube.Controllers
{
    public class UserManager : BaseController
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        private readonly IUserValidator _userValidator;

        public UserManager(ILogger logger, IEmailService emailService, IUserValidator userValidator)
        {
            _logger = logger;
            _emailService = emailService;
            _userValidator = userValidator;
        }

        public void LogMessage(string message)
        {
            _logger.LogMessage(message);
        }

        public void SendEmail(string user, string subject, string body)
        {
            _emailService.SendEmail(user, subject, body);
        }

        public bool ValidateUserInput(string user)
        {
            return _userValidator.ValidateUserInput(user);
        }
    }

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

    public interface IUserValidator
    {
        bool ValidateUserInput(string user);
    }

    public class UserValidator : IUserValidator
    {
        public bool ValidateUserInput(string user)
        {
            return !string.IsNullOrEmpty(user) && user.Length > 3;
        }
    }

    public class Program
    {
        public static void Main()
        {
            ILogger logger = new FileLogger();
            IEmailService emailService = new EmailService();
            IUserValidator userValidator = new UserValidator();

            var userManager = new UserManager(logger, emailService, userValidator);
            userManager.AddUser("JohnDoe");
            userManager.LogMessage("User JohnDoe added");
            userManager.SendEmail("JohnDoe", "Welcome", "Hello JohnDoe, welcome to our system!");
            bool isValid = userManager.ValidateUserInput("JohnDoe");
            Console.WriteLine($"Is valid user: {isValid}");

            IUserRepository userRepository = new UserRepository();
            INotificationService notificationService = new NotificationService();
            IAuditService auditService = new AuditService();

            userManager.AddUser("JohnDoe");
            userManager.RemoveUser("JohnDoe");

            var users = userManager.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}