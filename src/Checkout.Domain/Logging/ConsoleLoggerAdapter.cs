using System.Security.Cryptography.X509Certificates;
using Checkout.Domain.Interfaces;

namespace Checkout.Domain.Logging;

public class ConsoleLoggerAdapter :ILogger
{
    public static readonly ILogger Logger = new ConsoleLoggerAdapter();
    
    public void LogWarning(string message, params object[] args)
    {
        Console.WriteLine($"LogWarning: {message} {args}");
    }

    public void LogInformation(string message, params object[] args)
    {
        Console.WriteLine($"LogInformation: {message} {args}");
    } 
    
    public void LogError(string message, params object[] args)
    {
        Console.WriteLine($"LogError: {message} {args}");
    }
}