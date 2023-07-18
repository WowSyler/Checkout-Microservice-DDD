using Checkout.Domain.Base;

namespace Checkout.Domain.ItemAggregate;

public class VasItem : ValueObject
{
    public int Id { get; private set; }
    public int ItemId { get; private set; }
    public int CategoryId { get; private set; }
    public int SellerId { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    public VasItem(int id, int itemId, int categoryId, int sellerId, double price, int quantity)
    {
        Id = id;
        ItemId = itemId;
        CategoryId = categoryId;
        SellerId = sellerId;
        Price = price;
        Quantity = quantity;
    }
}