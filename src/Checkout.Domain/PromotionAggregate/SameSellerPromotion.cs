using Checkout.Domain.ItemAggregate;

namespace Checkout.Domain.PromotionAggregate;

public class SameSellerPromotion : Promotion
{
    public SameSellerPromotion() : base(9909)
    {
    }

    public override bool IsApplicable(List<Item> items)
    {
        var count = items.GroupBy(x => x.SellerId).Count();
        return count == 1;
    }

    public override double CalculateDiscount(double totalAmount)
    {
        double discount = totalAmount * 0.10; // %10 discount

        return discount;
    }
}