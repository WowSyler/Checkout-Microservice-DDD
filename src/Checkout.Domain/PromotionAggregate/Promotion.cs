using Checkout.Domain.Base;
using Checkout.Domain.ItemAggregate;

namespace Checkout.Domain.PromotionAggregate;

public abstract class Promotion : Entity, IAggregateRoot
{
    public int PromotionId { get; private set; }
    protected Promotion(int id)
    {
        PromotionId = id;
    }

    public abstract bool IsApplicable(List<Item> items);
    public abstract double CalculateDiscount(double totalAmount);

    public static List<Promotion> CreatePromotions()
    {
        return new List<Promotion>()
        {
            new CategoryPromotion(),
            new SameSellerPromotion(),
            new TotalPricePromotion()
        };
    }
}