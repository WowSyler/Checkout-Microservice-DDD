using Checkout.Console.Models;
using Checkout.Domain.Shared.Model.Command;

namespace Checkout.Console.Command;

public class ResetCartCommand : ICommand
{
    private readonly ResetCartModel _resetCartModel;

    public ResetCartCommand(ResetCartModel resetCartModel)
    {
        _resetCartModel = resetCartModel;
    }

    public Response Execute()
    {
        throw new NotImplementedException();
    }
}