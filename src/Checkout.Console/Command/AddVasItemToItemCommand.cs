using Checkout.Application.Handlers.CommandHandlers;
using Checkout.Console.Models;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class AddVasItemToItemCommand : ICommand
{
    private readonly AddVasItemToItemModel _addVasItemToItem;
    private readonly CartVasItemAddCommandHandler _addVasCommandHandler = new ();
    public AddVasItemToItemCommand(AddVasItemToItemModel addVasItemToItem)
    {
        _addVasItemToItem = addVasItemToItem;
    }

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Add Vas Item");

        return _addVasCommandHandler.AddVasItem(_addVasItemToItem.Payload);
    }
}