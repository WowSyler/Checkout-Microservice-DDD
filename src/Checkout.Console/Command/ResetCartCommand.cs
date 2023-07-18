using Checkout.Application.Handlers.QureyHandlers;
using Checkout.Console.Models;
using Checkout.Domain.Logging;

namespace Checkout.Console.Command;

public class ResetCartCommand : ICommand
{
    private readonly ResetCartQureyHandler _cartQueryHandler = new();

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Reset Cart");

        return _cartQueryHandler.ResetCart();
    }
}