using Checkout.Domain.Base;

namespace Checkout.Domain.ItemAggregate;

public sealed class Item : Entity, IAggregateRoot
{
    public int ItemId { get; private set; }
    public int CategoryId { get; private set; }
    public int SellerId { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }
    public List<VasItem>? VasItems { get; private set; }

    public Item(int itemId, int categoryId, int sellerId, double price, int quantity)
    {
        Id = itemId;
        ItemId = itemId;
        CategoryId = categoryId;
        SellerId = sellerId;
        Price = price;
        Quantity = quantity;
        VasItems = new List<VasItem>();
    }

    public bool AddVasItem(VasItem vasItem)
    {
        VasItems?.Add(vasItem);
        return true;
    }

    public bool UpdateQuantity(int quantity)
    {
        Quantity =+ quantity;
        return true;
    }
}