using Checkout.Console.Models;
using Checkout.Domain.Logging;

namespace Checkout.Console.Command;

//Command pattern
public class CommandInvoker
{
    private ICommand _command;
    private List<ICommand> _commandLists = new();

    public void SetCommand(ICommand tableActionCommand)
    {
        _command = tableActionCommand;
    }

    public void AddCommand(ICommand tableActionCommand)
    {
        _commandLists.Add(tableActionCommand);
    }

    public Response Execute()
    {
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute");
        return _command.Execute();
    }

    public List<Response> ExecuteAll()
    {
        List<Response> responses = new();
        _commandLists.ForEach(x => responses.Add(x.Execute()));
        ConsoleLoggerAdapter.Logger.LogInformation("Command Execute All");
        return responses;
    }
}