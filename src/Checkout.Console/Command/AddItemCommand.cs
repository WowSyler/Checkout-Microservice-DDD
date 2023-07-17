using Checkout.Console.Models;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class AddItemCommand : ICommand
{
    private readonly AddItemModel _addItemModel;
    
    public AddItemCommand(AddItemModel addItemModel)
    {
        _addItemModel = addItemModel;
    }
    public Response Execute()
    {
        throw new NotImplementedException();
    }
}