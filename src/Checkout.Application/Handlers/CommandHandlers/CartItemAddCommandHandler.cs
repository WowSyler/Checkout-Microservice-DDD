using Checkout.Application.Commands.Request;
using Checkout.Console.Models;
using Checkout.Infrastructure;

namespace Checkout.Application.Handlers.CommandHandlers;

public class CartItemAddCommandHandler
{
    public Response AddItem(CartAddItemRequest request)
    {
        var res = FakeDbContext.Cart.AddItem(request.ItemId, request.CategoryId, request.SellerId, request.Price,
            request.Quantity);

        if (res)
            return new Response() {Result = true, Message = "Item is added."};
        else
            return new Response() {Result = false, Message = "Item is not added."};
    }
}