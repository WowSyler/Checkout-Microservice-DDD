using Checkout.Application.Commands.Request;
using Checkout.Domain.Base;

namespace Checkout.Domain.Shared.Model.Command;

public class RemoveItemModel: BaseCommandModel
{
    public CartItemRemoveRequest? Payload { get; set; }
}


public class RemoveItemPayloadModel : ValueObject
{
    public int ItemId { get; set; }
}