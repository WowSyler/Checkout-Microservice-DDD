using Checkout.Console.Models;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class RemoveItemCommand : ICommand
{
    private readonly RemoveItemModel _removeItemModel;

    public RemoveItemCommand(RemoveItemModel removeItemModel)
    {
        _removeItemModel = removeItemModel;
    }

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Remove Item");

        throw new NotImplementedException();
    }
}