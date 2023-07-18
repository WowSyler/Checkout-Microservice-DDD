using Checkout.Domain.ItemAggregate;

namespace Checkout.Domain.PromotionAggregate;

public class CategoryPromotion: Promotion
{
    public CategoryPromotion() : base(5676)
    {
    }

    public override bool IsApplicable(List<Item> items)
    {
        return items.Any(x => x.CategoryId == 3003);
    }

    public override double CalculateDiscount(double totalAmount)
    {
        double discount = totalAmount * 0.05; // %5 discount

        return discount;
    }
}