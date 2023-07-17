using Checkout.Console.Models;
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
        throw new NotImplementedException();
    }
}