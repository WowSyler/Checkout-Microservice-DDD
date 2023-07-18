using Checkout.Console.Models;
using Checkout.Domain.CartAggregate;

namespace Checkout.Domain.UnitTests.Tests;

public class CartTests
{
    private Cart _cart; 
    public CartTests()
    {
        _cart = new();
    }
    
    [Fact]
    public void Cart_ResetCart_Successful()
    {
        //Arrange
        var res = true;

        //Act
        var cartRes = _cart.ResetCart();

        //Assert
        Assert.Equal(res, cartRes);
    }
    
    [Fact]
    public void Cart_GetCartInfo_Successful()
    {
        //Arrange
        var res = new Response()
        {
            Result = true,
            Message = ""
        };

        //Act
        var cartRes = _cart.GetCartInfo();

        //Assert
        Assert.Equal(res.Result, cartRes.Result);
    }
    
    [Fact]
    public void Cart_AddItem_Successful()
    {
        //Arrange
        var res = true;

        //Act
        var cartRes = _cart.AddItem(1,9001,22,345,3);

        //Assert
        Assert.Equal(res, cartRes);
    }
    
    [Fact]
    public void Cart_RemoveItem_Fail()
    {
        //Arrange
        var res = false;

        //Act
        var cartRes = _cart.RemoveItem(1);

        //Assert
        Assert.Equal(res, cartRes);
    }
    
    [Fact]
    public void Cart_AddVasItem_Fail()
    {
        //Arrange
        var res = false;

        //Act
        var cartVasRes = _cart.AddVasItemToItem(1, 12,3242,5003,4553.5,2);

        //Assert
        Assert.Equal(res, cartVasRes);
    }
    
    [Fact]
    public void Cart_AddVasItem_Successful()
    {
        //Arrange
        var res = true;

        //Act
        _cart.AddItem(1,1001,22,3458,3);
        var cartVasRes = _cart.AddVasItemToItem(1, 12,3242,5003,453.5,2);

        //Assert
        Assert.Equal(res, cartVasRes);
    }
}