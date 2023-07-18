using Checkout.Application.Handlers.CommandHandlers;
using Checkout.Console.Models;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class AddItemCommand : ICommand
{
    private readonly AddItemModel _addItemModel;
    private readonly CartItemAddCommandHandler _addCommandHandler = new ();
    
    public AddItemCommand(AddItemModel addItemModel)
    {
        _addItemModel = addItemModel;
    }
    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute - Add Item");

        return _addCommandHandler.AddItem(_addItemModel.Payload);
    }
}