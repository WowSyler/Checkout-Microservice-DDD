
using Checkout.Application.Handlers.QureyHandlers;
using Checkout.Console.Models;

namespace Checkout.Application.UnitTests.Test;

public class QueryHandlerTest
{
    private GetShowCartQueryHandler _cartQueryHandler;
    private ResetCartQureyHandler _resetCartQureyHandler;

    public QueryHandlerTest()
    {
        _cartQueryHandler = new GetShowCartQueryHandler();
        _resetCartQureyHandler = new ResetCartQureyHandler();
    }
    
    
    [Fact]
    public void Cart_QueryGetShowHandle_Successful()
    {
        //Arrange
        var res = new Response()
        {
            Result = true
        };

        //Act
        var cartRes = _cartQueryHandler.ShowCart();

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }

    [Fact]
    public void Cart_QueryResetHandler_Successful()
    {
        //Arrange
        var res = new Response()
        {
            Result = true
        };

        //Act
        var cartRes = _resetCartQureyHandler.ResetCart();

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }

}