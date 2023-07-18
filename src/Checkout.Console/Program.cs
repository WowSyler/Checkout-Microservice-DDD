using Checkout.Application.Constants;
using Checkout.Application.Exceptions;
using Checkout.Application.Extensions;
using Checkout.Console.Command;
using Checkout.Domain.Logging;
using Checkout.Domain.Shared.Enums;
using Checkout.Domain.Shared.Model.Command;
using Checkout.Infrastructure.Data;
using Newtonsoft.Json;

namespace Checkout.Console;

public static class Program
{
    
    public static void Main(string[] args)
    {
        Exceptions.SetGlobalExceptionHandler();
        try
        {
            ConsoleLoggerAdapter.Logger.LogInformation("Checkout Start!");
            FakeData.SetFakeData(); // change

            while (true)
            {
                var readLine = System.Console.ReadLine()?.ToLower() ?? "input";
                if (readLine is "e" or "exit") break; // Exit

                var type = readLine.ToEnum<CommandName>(); // toEnum Extension
                var json = string.Empty;
                var lines = File.ReadAllLines(CommandConstants.InputFolder + type.ToString().ToLower() +
                                              CommandConstants.File);
                if (lines.Length > 0)
                    json = lines[0].Trim();

                var commandModel = JsonConvert.DeserializeObject<BaseCommandModel>(json);
                if (commandModel is null)
                {
                    ConsoleLoggerAdapter.Logger.LogWarning("File is null");
                    continue;
                }

                ConsoleLoggerAdapter.Logger.LogInformation($"Command run : {commandModel.Command}");

                CommandRun(commandModel.Command, json);
            }
        }
        catch (Exception e)
        {
            ConsoleLoggerAdapter.Logger.LogError("Checkout End with Error!");
            ConsoleLoggerAdapter.Logger.LogError(e.Message);
            throw;
        }
        finally
        {
            ConsoleLoggerAdapter.Logger.LogInformation("Checkout End!");
        }
    }


    private static void CommandRun(CommandName commandName, string json)
    {
        var commandInvoker = new CommandInvoker();
        switch (commandName)
        {
            case CommandName.AddItem:
                var addItemModel = JsonConvert.DeserializeObject<AddItemModel>(json)!;
                var addItemCommand = new AddItemCommand(addItemModel);
                commandInvoker.SetCommand(addItemCommand);
                break;
            case CommandName.AddVasItemToItem:
                var addVasItemToItemModel = JsonConvert.DeserializeObject<AddVasItemToItemModel>(json)!;
                var addVasItemToItemCommand = new AddVasItemToItemCommand(addVasItemToItemModel);
                commandInvoker.SetCommand(addVasItemToItemCommand);
                break;
            case CommandName.RemoveItem:
                var removeItemModel = JsonConvert.DeserializeObject<RemoveItemModel>(json)!;
                var removeItemCommand = new RemoveItemCommand(removeItemModel);
                commandInvoker.SetCommand(removeItemCommand);
                break;
            case CommandName.ResetCart:
                var resetCartCommand = new ResetCartCommand();
                commandInvoker.SetCommand(resetCartCommand);
                break;
            case CommandName.DisplayCart:
                var displayCartCommand = new DisplayCartCommand();
                commandInvoker.SetCommand(displayCartCommand);
                break;
            default:
                ConsoleLoggerAdapter.Logger.LogError("Wrong command");
                throw new ArgumentOutOfRangeException();
        }

        ConsoleLoggerAdapter.Logger.LogInformation(json);
        var response = commandInvoker.Execute();
        var resString = JsonConvert.SerializeObject(response);
        ConsoleLoggerAdapter.Logger.LogInformation(resString);
        File.WriteAllText(CommandConstants.OutputFolder, resString);
    }
}