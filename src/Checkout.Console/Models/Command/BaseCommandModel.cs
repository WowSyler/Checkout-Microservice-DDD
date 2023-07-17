using Checkout.Domain.Base;
using Checkout.Domain.Shared.Enums;

namespace Checkout.Domain.Shared.Model.Command;

public class BaseCommandModel: ValueObject
{
    public CommandName Command { get; set; }
}