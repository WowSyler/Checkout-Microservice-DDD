using Checkout.Domain.PromotionAggregate;

namespace Checkout.Domain.UnitTests.Tests;

public class PromotionTests
{
    private Promotion _promotionCat;
    private Promotion _promotionSame;
    private Promotion _promotionTotal;

    public PromotionTests()
    {
        _promotionCat = new CategoryPromotion();
        _promotionSame = new SameSellerPromotion();
        _promotionTotal = new TotalPricePromotion();
    }
    
    
    [Fact]
    public void Promotion_SameSeller_Successful()
    {
        //Arrange
        var res = 100;

        //Act
        var itemRes = _promotionSame.CalculateDiscount(1000);

        //Assert
        Assert.Equal(res, itemRes);
    }
    
    [Fact]
    public void Promotion_SameSeller_Fail()
    {
        //Arrange
        var res = 1000;

        //Act
        var itemRes = _promotionSame.CalculateDiscount(1000);

        //Assert
        Assert.NotEqual(res, itemRes);
    }
    
    [Fact]
    public void Promotion_Category_Successful()
    {
        //Arrange
        var res = 50;

        //Act
        var itemRes = _promotionCat.CalculateDiscount(1000);

        //Assert
        Assert.Equal(res, itemRes);
    }
    
    [Fact]
    public void Promotion_Category_Fail()
    {
        //Arrange
        var res = 1000;

        //Act
        var itemRes = _promotionSame.CalculateDiscount(1000);

        //Assert
        Assert.NotEqual(res, itemRes);
    }
    
    
    [Fact]
    public void Promotion_Total_Successful()
    {
        //Arrange
        var res = 250;

        //Act
        var itemRes = _promotionTotal.CalculateDiscount(1000);

        //Assert
        Assert.Equal(res, itemRes);
    }
    
    [Fact]
    public void Promotion_Total_Fail()
    {
        //Arrange
        var res = 1000;

        //Act
        var itemRes = _promotionTotal.CalculateDiscount(1000);

        //Assert
        Assert.NotEqual(res, itemRes);
    }
}