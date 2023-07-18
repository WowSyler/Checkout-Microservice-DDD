using Checkout.Application.Commands.Request;
using Checkout.Console.Models;
using Checkout.Infrastructure;

namespace Checkout.Application.Handlers.CommandHandlers;

public class CartItemRemoveCommandHandler
{
    public Response RemoveItem(CartItemRemoveRequest request)
    {
        var res = FakeDbContext.Cart.RemoveItem(request.ItemId);
        
        if (res)
            return new Response() {Result = true, Message = "Item is remove."};
        else
            return new Response() {Result = false, Message = "Item is not removed."};
    }
}