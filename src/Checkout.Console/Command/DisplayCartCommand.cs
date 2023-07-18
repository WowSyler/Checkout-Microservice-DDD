using Checkout.Application.Handlers.QureyHandlers;
using Checkout.Console.Models;
using Checkout.Domain.Logging;

namespace Checkout.Console.Command;

public class DisplayCartCommand : ICommand
{
    private readonly GetShowCartQueryHandler _cartQueryHandler = new(); 
    

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Display Cart");

        return _cartQueryHandler.ShowCart();
    }
}