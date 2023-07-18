using Checkout.Application.Commands.Request;
using Checkout.Application.Handlers.CommandHandlers;
using Checkout.Console.Models;

namespace Checkout.Application.UnitTests.Test;

public class CommandHandlerTest
{
    private CartItemAddCommandHandler _cartItemAddCommandHandler;
    private CartItemRemoveCommandHandler _cartItemRemoveCommandHandler;
    private CartVasItemAddCommandHandler _cartVasItemAddCommandHandler;

    public CommandHandlerTest()
    {
        _cartVasItemAddCommandHandler = new CartVasItemAddCommandHandler();
        _cartItemRemoveCommandHandler = new CartItemRemoveCommandHandler();
        _cartItemAddCommandHandler = new CartItemAddCommandHandler();
    }

    [Fact]
    public void Cart_AddItemCommandHandle_Successful()
    {
        //Arrange
        var res = new Response()
        {
            Result = true
        };

        //Act
        var cartRes = _cartItemAddCommandHandler.AddItem(new CartAddItemRequest()
            {CategoryId = 1, ItemId = 2, Price = 22.3, Quantity = 1, SellerId = 3});

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }
    
    [Fact]
    public void Cart_RemoveItemCommandHandle_Fail()
    {
        //Arrange
        var res = new Response()
        {
            Result = false
        };

        //Act
        var cartRes = _cartItemRemoveCommandHandler.RemoveItem(new CartItemRemoveRequest(){ItemId = 1});

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }
    
    [Fact]
    public void Cart_AddVasItemCommandHandle_Fail()
    {
        //Arrange
        var res = new Response()
        {
            Result = false
        };

        //Act
        // todo add item
        var cartRes = _cartVasItemAddCommandHandler.AddVasItem(new CartAddVasItemRequest()
            {CategoryId = 3242, ItemId = 2, Price = 22.3, Quantity = 1, SellerId = 5003});

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }
}