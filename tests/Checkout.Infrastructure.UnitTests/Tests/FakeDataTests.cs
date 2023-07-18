using Checkout.Domain.CartAggregate;
using Checkout.Infrastructure.Data;

namespace Checkout.Infrastructure.UnitTests.Tests;

public class FakeDataTests
{

    [Fact]
    public void Get_FakeData_Fail()
    {
        //Arrange
        var newCart = new Cart(){Id = 1};

        //Act
        var cart = FakeDbContext.Cart;

        //Assert
        Assert.Equal(newCart.Id, cart.Id);
    }
    
}