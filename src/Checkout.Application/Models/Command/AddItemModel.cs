using Checkout.Application.Commands.Request;
using Checkout.Domain.Base;

namespace Checkout.Domain.Shared.Model.Command;

public class AddItemModel: BaseCommandModel
{
    public CartAddItemRequest Payload { get; set; }
}


public class AddItemPayloadModel : ValueObject
{
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public int SellerId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}