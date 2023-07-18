using Checkout.Domain.CartAggregate;
using Checkout.Domain.ItemAggregate;
using Checkout.Domain.PromotionAggregate;

namespace Checkout.Infrastructure;

public static class FakeDbContext
{
   
    public static readonly Cart Cart = new() {Id = 1};
    public static readonly List<Promotion> Promotions = Promotion.CreatePromotions();
    public static readonly List<Item> Items = new();
}