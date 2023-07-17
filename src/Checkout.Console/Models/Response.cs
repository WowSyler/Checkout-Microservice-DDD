using Checkout.Domain.Base;

namespace Checkout.Console.Models;

public class Response : ValueObject
{
    public bool Result { get; set; }
    public string? Message { get; set; }
}