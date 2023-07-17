using Checkout.Console.Models;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class DisplayCartCommand : ICommand
{
    private readonly DisplayCartModel _displayCartModel;

    public DisplayCartCommand(DisplayCartModel displayCartModel)
    {
        _displayCartModel = displayCartModel;
    }

    public Response Execute()
    {
        throw new NotImplementedException();
    }
}