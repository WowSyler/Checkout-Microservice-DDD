using Checkout.Application.Commands.Request;
using Checkout.Console.Models;
using Checkout.Infrastructure;

namespace Checkout.Application.Handlers.CommandHandlers;

public class CartVasItemAddCommandHandler
{
    public Response AddVasItem(CartAddVasItemRequest request)
    {
        var res = FakeDbContext.Cart.AddVasItemToItem(request.ItemId, request.VasItemId, request.CategoryId,
            request.SellerId, request.Price, request.Quantity);

        if (res)
            return new Response() {Result = true, Message = "Vas Item is added."};
        else
            return new Response() {Result = false, Message = "Vas Item is not added."};
    }
}