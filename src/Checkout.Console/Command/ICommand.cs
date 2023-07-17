using Checkout.Console.Models;

namespace Checkout.Console.Command;

public interface ICommand
{
    Response Execute();
}