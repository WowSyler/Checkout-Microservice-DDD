using Checkout.Domain.Base;

namespace Checkout.Domain.Shared.Model.Command;

public class RemoveItemModel: BaseCommandModel
{
    public RemoveItemPayloadModel? Payload { get; set; }
}


public class RemoveItemPayloadModel : ValueObject
{
    public int ItemId { get; set; }
}