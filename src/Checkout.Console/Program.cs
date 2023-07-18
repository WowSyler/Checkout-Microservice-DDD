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
                if (readLine is "auto")
                {
                    CommandAuto(); // auto add 4 item, 1 vas item, 1 item remove, display cart and reset cart.
                    break;
                }

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
            ConsoleLoggerAdapter.Logger.LogError(e.Message, e);
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
                File.WriteAllText(CommandConstants.OutputFolder, json);
                break;
            case CommandName.AddVasItemToItem:
                var addVasItemToItemModel = JsonConvert.DeserializeObject<AddVasItemToItemModel>(json)!;
                var addVasItemToItemCommand = new AddVasItemToItemCommand(addVasItemToItemModel);
                commandInvoker.SetCommand(addVasItemToItemCommand);
                File.WriteAllText(CommandConstants.OutputFolder, json);
                break;
            case CommandName.RemoveItem:
                var removeItemModel = JsonConvert.DeserializeObject<RemoveItemModel>(json)!;
                var removeItemCommand = new RemoveItemCommand(removeItemModel);
                commandInvoker.SetCommand(removeItemCommand);
                File.WriteAllText(CommandConstants.OutputFolder, json);
                break;
            case CommandName.ResetCart:
                var resetCartModel = JsonConvert.DeserializeObject<ResetCartModel>(json)!;
                var resetCartCommand = new ResetCartCommand(resetCartModel);
                commandInvoker.SetCommand(resetCartCommand);
                File.WriteAllText(CommandConstants.OutputFolder, json);
                break;
            case CommandName.DisplayCart:
                var displayCartModel = JsonConvert.DeserializeObject<DisplayCartModel>(json)!;
                var displayCartCommand = new DisplayCartCommand(displayCartModel);
                commandInvoker.SetCommand(displayCartCommand);
                File.WriteAllText(CommandConstants.OutputFolder, json);
                break;
            default:
                ConsoleLoggerAdapter.Logger.LogError("Wrong command");
                throw new ArgumentOutOfRangeException();
        }

        commandInvoker.Execute();
    }


    private static void CommandAuto()
    {
        var commandInvoker = new CommandInvoker();

        // add item
        var addItemModel = JsonConvert.DeserializeObject<AddItemModel>(AutoItemAddConstants.Item1)!;
        var addItemCommand = new AddItemCommand(addItemModel);
        commandInvoker.SetCommand(addItemCommand);

        var addItemModel2 = JsonConvert.DeserializeObject<AddItemModel>(AutoItemAddConstants.Item2)!;
        var addItemCommand2 = new AddItemCommand(addItemModel2);
        commandInvoker.SetCommand(addItemCommand2);

        var addItemModel3 = JsonConvert.DeserializeObject<AddItemModel>(AutoItemAddConstants.Item3)!;
        var addItemCommand3 = new AddItemCommand(addItemModel3);
        commandInvoker.SetCommand(addItemCommand3);

        var addItemModel4 = JsonConvert.DeserializeObject<AddItemModel>(AutoItemAddConstants.Item4)!;
        var addItemCommand4 = new AddItemCommand(addItemModel4);
        commandInvoker.SetCommand(addItemCommand4);

        // remove 1 item
        var removeItemModel = JsonConvert.DeserializeObject<RemoveItemModel>(AutoItemAddConstants.ItemRemove)!;
        var removeItemCommand = new RemoveItemCommand(removeItemModel);
        commandInvoker.SetCommand(removeItemCommand);

        // add vas item
        var addVasItemToItemModel = JsonConvert.DeserializeObject<AddVasItemToItemModel>(AutoItemAddConstants.VasItem)!;
        var addVasItemToItemCommand = new AddVasItemToItemCommand(addVasItemToItemModel);
        commandInvoker.SetCommand(addVasItemToItemCommand);

        // display cart
        var displayCartModel = JsonConvert.DeserializeObject<DisplayCartModel>(AutoItemAddConstants.DisplayCart)!;
        var displayCartCommand = new DisplayCartCommand(displayCartModel);
        commandInvoker.SetCommand(displayCartCommand);

        // reset cart
        var resetCartModel = JsonConvert.DeserializeObject<ResetCartModel>(AutoItemAddConstants.ResetCart)!;
        var resetCartCommand = new ResetCartCommand(resetCartModel);
        commandInvoker.SetCommand(resetCartCommand);

        File.WriteAllText(CommandConstants.OutputFolder, AutoItemAddConstants.FileWriteMsg);
        commandInvoker.ExecuteAll();
    }
}