using Checkout.Domain.Interfaces;

namespace Checkout.Domain.Logging;

public class ConsoleLoggerAdapter :ILogger
{
    public static readonly ILogger Logger = new ConsoleLoggerAdapter();
    
    public void LogWarning(string message)
    {
        System.Console.WriteLine($"LogWarning: {message}");
    }

    public void LogInformation(string message)
    {
        System.Console.WriteLine($"LogInformation: {message}");
    } 
    
    public void LogError(string message)
    {
        System.Console.WriteLine($"LogError: {message}");
    }
}