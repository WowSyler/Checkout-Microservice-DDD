using Checkout.Console.Models;
using Checkout.Infrastructure;

namespace Checkout.Application.Handlers.QureyHandlers;

public class GetShowCartQueryHandler
{
    public Response ShowCart()
    {
        return FakeDbContext.Cart.GetCartInfo();
    }
}