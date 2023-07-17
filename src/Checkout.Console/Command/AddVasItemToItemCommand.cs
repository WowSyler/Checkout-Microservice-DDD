using Checkout.Console.Models;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class AddVasItemToItemCommand : ICommand
{
    private readonly AddVasItemToItemModel _addVasItemToItem;

    public AddVasItemToItemCommand(AddVasItemToItemModel addVasItemToItem)
    {
        _addVasItemToItem = addVasItemToItem;
    }

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Add Vas Item");

        throw new NotImplementedException();
    }
}