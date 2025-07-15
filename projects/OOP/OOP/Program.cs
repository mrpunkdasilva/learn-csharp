using System;
using System.Collections.Generic;
using System.IO;

// Encapsulation: Logger
public class Logger
{
    private readonly string _logFilePath;

    public Logger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void LogMessage(string message)
    {
        try
        {
            File.AppendAllText(_logFilePath, $"[{DateTime.Now}] {message}\n");
            Console.WriteLine($"Logged: {message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging message: {ex.Message}");
        }
    }

    public string ReadLogs()
    {
        try
        {
            if (File.Exists(_logFilePath))
            {
                return File.ReadAllText(_logFilePath);
            }
            return "Log file does not exist.";
        }
        catch (Exception ex)
        {
            return $"Error reading logs: {ex.Message}";
        }
    }
}

// Abstraction: Notification Service
public abstract class NotificationService
{
    public abstract void SendNotification(string recipient, string message);

    public void LogAttempt(string recipient, string message)
    {
        Console.WriteLine($"Attempting to send notification to {recipient}: '{message}'");
    }
}

public class EmailNotificationService : NotificationService
{
    public override void SendNotification(string recipient, string message)
    {
        LogAttempt(recipient, message);
        Console.WriteLine($"Sending email to {recipient}: {message}");
        // Logic for sending actual email
    }
}

public class SmsNotificationService : NotificationService
{
    public override void SendNotification(string recipient, string message)
    {
        LogAttempt(recipient, message);
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }
}

// Inheritance: User Accounts
public class UserAccount
{
    public string Username { get; set; }
    public string Email { get; set; }

    public UserAccount(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine($"User: {Username}, Email: {Email}");
    }

    public void Login()
    {
        Console.WriteLine($"{Username} logged in.");
    }
}

public class AdministratorAccount : UserAccount
{
    public string Department { get; set; }

    public AdministratorAccount(string username, string email, string department) : base(username, email)
    {
        Department = department;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"Administrator: {Username}, Email: {Email}, Dept: {Department}");
    }

    public void ManageUsers()
    {
        Console.WriteLine($"Administrator {Username} is managing users.");
    }
}

public class DeveloperAccount : UserAccount
{
    public string ProgrammingLanguage { get; set; }

    public DeveloperAccount(string username, string email, string programmingLanguage) : base(username, email)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public override void DisplayRole()
{
        Console.WriteLine($"Developer: {Username}, Email: {Email}, Lang: {ProgrammingLanguage}");
    }

    public void WriteCode()
    {
        Console.WriteLine($"Developer {Username} is writing code in {ProgrammingLanguage}.");
    }
}

// Polymorphism: Data Serializers
public interface IDataSerializer
{
    string Serialize<T>(T data);
    T Deserialize<T>(string serializedData);
}

public class JsonSerializer : IDataSerializer
{
    public string Serialize<T>(T data)
    {
        Console.WriteLine($"Serializing data to JSON...");
        return $"{{ \"type\": \"{typeof(T).Name}\", \"data\": \"{data.ToString()}\" }}";
    }

    public T Deserialize<T>(string serializedData)
    {
        Console.WriteLine($"Deserializing data from JSON...");
        return default(T);
    }
}

public class XmlSerializer : IDataSerializer
{
    public string Serialize<T>(T data)
    {
        Console.WriteLine($"Serializing data to XML...");
        return $"<root><type>{typeof(T).Name}</type><data>{data.ToString()}</data></root>";
    }

    public T Deserialize<T>(string serializedData)
    {
        Console.WriteLine($"Deserializing data from XML...");
        return default(T);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Encapsulation Example (Logger) ---");
        string logFile = "application.log";
        Logger appLogger = new Logger(logFile);
        appLogger.LogMessage("Application started.");
        appLogger.LogMessage("User 'admin' logged in.");
        Console.WriteLine("\n--- Reading Logs ---\n" + appLogger.ReadLogs());

        Console.WriteLine("\n--- Abstraction Example (Notification Service) ---");
        NotificationService emailService = new EmailNotificationService();
        emailService.SendNotification("user@example.com", "Your order has been shipped.");

        NotificationService smsService = new SmsNotificationService();
        smsService.SendNotification("+1234567890", "Your password reset code is 12345.");

        Console.WriteLine("\n--- Inheritance Example (User Accounts) ---");
        UserAccount regularUser = new UserAccount("john.doe", "john@example.com");
        regularUser.DisplayRole();
        regularUser.Login();

        AdministratorAccount adminUser = new AdministratorAccount("jane.admin", "jane@example.com", "IT");
        adminUser.DisplayRole();
        adminUser.Login();
        adminUser.ManageUsers();

        DeveloperAccount devUser = new DeveloperAccount("dev.coder", "dev@example.com", "C#");
        devUser.DisplayRole();
        devUser.Login();
        devUser.WriteCode();

        Console.WriteLine("\n--- Polymorphism Example (Data Serializers) ---");
        IDataSerializer jsonSerializer = new JsonSerializer();
        string jsonData = jsonSerializer.Serialize(new { Name = "ProductA", Price = 99.99 });
        Console.WriteLine($"Serialized JSON: {jsonData}");
        var deserializedJson = jsonSerializer.Deserialize<object>(jsonData);

        IDataSerializer xmlSerializer = new XmlSerializer();
        string xmlData = xmlSerializer.Serialize(new { Id = 123, Status = "Active" });
        Console.WriteLine($"Serialized XML: {xmlData}");
        var deserializedXml = xmlSerializer.Deserialize<object>(xmlData);
        
        List<IDataSerializer> serializers = new List<IDataSerializer>
        {
            new JsonSerializer(),
            new XmlSerializer()
        };

        Console.WriteLine("\n--- Polymorphism with List of Serializers ---");
        foreach (var serializer in serializers)
        {
            serializer.Serialize("Sample Data");
        }
    }
}