using Checkout.Console.Models;
using Checkout.Infrastructure;

namespace Checkout.Application.Handlers.QureyHandlers;

public class ResetCartQureyHandler
{
    public Response ResetCart()
    {
        FakeDbContext.Cart.ResetCart();
        return new Response()
        {
            Result = true,
            Message = "Cart reset"
        };
    }
}