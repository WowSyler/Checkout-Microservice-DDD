using Checkout.Domain.ItemAggregate;

namespace Checkout.Domain.UnitTests.Tests;

public class ItemTests
{
    private Item _item; 
    public ItemTests()
    {
        _item = new Item(1, 2, 3, 2.3, 1);
    }
    
    [Fact]
    public void Item_AddVasItem_Successful()
    {
        //Arrange
        var res = true;

        //Act
        var vasItem = new VasItem(1, 2, 3, 4, 2, 1);
        var itemRes = _item.AddVasItem(vasItem);

        //Assert
        Assert.Equal(res, itemRes);
    }
    
    [Fact]
    public void Item_UpdateQuantity_Successful()
    {
        //Arrange
        var res = true;

        //Act
        var itemRes = _item.UpdateQuantity(1);

        //Assert
        Assert.Equal(res, itemRes);
    }
}