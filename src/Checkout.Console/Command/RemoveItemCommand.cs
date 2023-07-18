using Checkout.Application.Handlers.CommandHandlers;
using Checkout.Console.Models;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class RemoveItemCommand : ICommand
{
    private readonly RemoveItemModel _removeItemModel;
    private readonly CartItemRemoveCommandHandler _removeCommandHandler = new ();

    public RemoveItemCommand(RemoveItemModel removeItemModel)
    {
        _removeItemModel = removeItemModel;
    }

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Remove Item");

        return _removeCommandHandler.RemoveItem(_removeItemModel.Payload);
    }
}