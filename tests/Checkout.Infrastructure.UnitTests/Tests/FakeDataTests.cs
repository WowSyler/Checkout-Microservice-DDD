using Checkout.Infrastructure.Data;

namespace Checkout.Infrastructure.UnitTests.Tests;

public class FakeDataTests
{

    [Fact]
    public void Get_FakeData_Fail()
    {
        //Arrange
        var count = 0;

        //Act
        var cartCount = FakeDbContext.Carts.Count;

        //Assert
        Assert.Equal(count, cartCount);
    }
    
    [Fact]
    public void Get_FakeData_Successful()
    {
        //Arrange
        var count = 5;

        //Act
        FakeData.SetFakeData();
        var cartCount = FakeDbContext.Carts.Count;

        //Assert
        Assert.Equal(count, cartCount);
    }
}