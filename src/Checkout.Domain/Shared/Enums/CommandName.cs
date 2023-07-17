using System.Runtime.Serialization;

namespace Checkout.Domain.Shared.Enums;

public enum CommandName
{
    [EnumMember(Value = "input")] Input = 0,
    [EnumMember(Value = "addItem")] AddItem = 1,
    [EnumMember(Value = "addVasItemToItem")] AddVasItemToItem = 2,
    [EnumMember(Value = "removeItem")] RemoveItem = 3,
    [EnumMember(Value = "resetCart")] ResetCart = 4,
    [EnumMember(Value = "displayCart")] DisplayCart = 5,
}