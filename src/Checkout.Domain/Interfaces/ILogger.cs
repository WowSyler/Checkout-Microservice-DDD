namespace Checkout.Domain.Interfaces;

public interface ILogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
}