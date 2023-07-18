using Checkout.Application.Commands.Request;
using Checkout.Domain.Base;

namespace Checkout.Domain.Shared.Model.Command;

public class AddVasItemToItemModel: BaseCommandModel
{
    public CartAddVasItemRequest Payload { get; set; }
}


public class AddVasItemToItemPayloadModel : ValueObject
{
    public int ItemId { get; set; }
    public int VasItemId { get; set; }
    public int CategoryId { get; set; }
    public int SellerId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}