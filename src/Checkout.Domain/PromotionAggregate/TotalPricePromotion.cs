using Checkout.Domain.ItemAggregate;

namespace Checkout.Domain.PromotionAggregate;

public class TotalPricePromotion : Promotion
{
    public TotalPricePromotion() : base(1232)
    {
    }

    public override bool IsApplicable(List<Item> items)
    {
        return true;
    }

    public override double CalculateDiscount(double totalAmount)
    {
        double discount = 0;
        switch (totalAmount)
        {
            case < 5000:
                discount = 250;
                break;
            case >= 5000 and < 10000:
                discount = 500;
                break;
            case >= 10000 and < 50000:
                discount = 1000;
                break;
            case >= 50000:
                discount = 2000;
                break;
        }

        return discount;
    }
}