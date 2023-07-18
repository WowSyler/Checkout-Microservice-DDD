using Checkout.Console.Models;
using Checkout.Domain.Base;
using Checkout.Domain.ItemAggregate;
using Checkout.Domain.PromotionAggregate;

namespace Checkout.Domain.CartAggregate;

public class Cart : Entity, IAggregateRoot
{
    private const int MaxUniqueItems = 10;
    private const int MaxDigitalItems = 5;
    private const int MaxTotalProducts = 30;
    private const double MaxTotalAmount = 500000;

    private readonly List<Item> items;
    private readonly List<Promotion> promotions;

    public Cart()
    {
        items = new List<Item>();
        promotions = Promotion.CreatePromotions();
    }

    public bool AddItem(int itemId, int categoryId, int sellerId, double price, int quantity)
    {
        // max total unique items
        if (items.Count > MaxUniqueItems)
        {
            return false;
        }

        // max total items
        int totalQuantity = items.Sum(item => item.Quantity);
        int totalVasItemQuantity = items.Sum(item => item.VasItems!.Sum(x => x.Quantity));
        if (totalQuantity + totalVasItemQuantity + quantity > MaxTotalProducts)
        {
            return false;
        }

        // DigitalItem max
        if (categoryId == 7889)
        {
            var digitalItems = items.Where(x => x.CategoryId == 7889).ToList();
            int totalDigitalQuantity = digitalItems.Sum(item => item.Quantity);
            if (totalDigitalQuantity + quantity > MaxDigitalItems)
            {
                return false;
            }
        }

        // max amount 
        double totalAmount = items.Sum(item => item.Price * item.Quantity);
        double totalVasItemAmount = items.Sum(item => item.VasItems!.Sum(x => x.Price * item.Quantity));
        if (totalAmount + totalVasItemAmount + (price * quantity) > MaxTotalAmount)
        {
            return false;
        }

        //The maximum quantity of an item that can be added is 10. 
        if (quantity > 10)
        {
            return false;
        }

        if (IsAddItemVasItemCheck(sellerId, categoryId))
        {
            return false;
        }

        Item existingItem = items.FirstOrDefault(item => item.ItemId == itemId);
        if (existingItem != null)
        {
            //The maximum quantity of an item that can be added is 10. 
            if (existingItem.Quantity + quantity > 10)
            {
                return false;
            }

            existingItem.UpdateQuantity(quantity);
            return true;
        }

        Item newItem = new Item(itemId, categoryId, sellerId, price, quantity);
        items.Add(newItem);

        return true;
    }

    public bool AddVasItemToItem(int parentItemId, int vasItemId, int categoryId, int sellerId,
        double price, int quantity)
    {
        Item parentItem = items.FirstOrDefault(item => item.ItemId == parentItemId);
        if (parentItem == null)
        {
            return false;
        }

        if (IsVasItemCheck(sellerId, categoryId))
        {
            return false;
        }

        // only this category
        if (parentItem.CategoryId is not (1001 or 3004))
        {
            return false;
        }

        // only this category
        if (parentItem.CategoryId is 3242)
        {
            return false;
        }

        //Max vas item
        int totalVasItemQuantity = items.Sum(item => item.VasItems!.Sum(x => x.Quantity));
        if (totalVasItemQuantity >= 3)
        {
            return false;
        }

        // amount check
        if (parentItem.Price < price)
        {
            return false;
        }


        VasItem vasItem = new VasItem(vasItemId, parentItemId, categoryId, sellerId, price, quantity);
        parentItem.AddVasItem(vasItem);

        return true;
    }

    public bool RemoveItem(int itemId)
    {
        Item itemToRemove = items.FirstOrDefault(item => item.ItemId == itemId);
        if (itemToRemove == null)
        {
            return false;
        }

        items.Remove(itemToRemove);
        return true;
    }

    public bool ResetCart()
    {
        items.Clear();
        return true;
    }

    public Response GetCartInfo()
    {
        // cart info
        try
        {
            double totalPrice = items.Sum(item => item.Price * item.Quantity);
            double totalVasItemPrice = items.Sum(item => item.VasItems!.Sum(x => x.Price * x.Quantity));
            var promotionResult = CalculateTotalDiscount();

            var cartItems = items.Select(item =>
            {
                var vasItems = item.VasItems.Select(vasItem =>
                {
                    return new
                    {
                        vasItemId = vasItem.ItemId,
                        categoryId = vasItem.CategoryId,
                        sellerId = vasItem.SellerId,
                        price = vasItem.Price,
                        quantity = vasItem.Quantity
                    };
                }).ToList();

                return new
                {
                    itemId = item.ItemId,
                    categoryId = item.CategoryId,
                    sellerId = item.SellerId,
                    price = item.Price,
                    quantity = item.Quantity,
                    vasItems = vasItems
                };
            }).ToList();

            var res = new
            {
                items = cartItems,
                totalPrice = totalPrice + totalVasItemPrice,
                appliedPromotionId = promotionResult.AppliedPromotionId,
                totalDiscount = promotionResult.Discount
            };

            return new Response()
            {
                Result = true,
                Message = res
            };
        }
        catch (Exception e)
        {
            return new Response()
            {
                Result = false,
                Message = "error"
            };
        }
    }

    private CalculateResponse CalculateTotalDiscount()
    {
        double totalAmount = items.Sum(item => item.Price * item.Quantity);
        double totalVasItemPrice = items.Sum(item => item.VasItems!.Sum(x => x.Price * x.Quantity));
        double total = totalAmount + totalVasItemPrice;
        double discount = 0;
        int appliedPromotionId = 0;
        
        foreach (var promotion in promotions)
        {
            if (promotion is SameSellerPromotion && promotion.IsApplicable(items))
            {
                var discountNew = Math.Max(discount, promotion.CalculateDiscount(total));
                if (!(discountNew > discount)) continue;
                appliedPromotionId = promotion.PromotionId;
                discount = discountNew;
            }
            else if (promotion is CategoryPromotion && promotion.IsApplicable(items))
            {
                var discountNew = Math.Max(discount, promotion.CalculateDiscount(total));
                if (!(discountNew > discount)) continue;
                appliedPromotionId = promotion.PromotionId;
                discount = discountNew;
            }
            else if (promotion is TotalPricePromotion && promotion.IsApplicable(items))
            {
                var discountNew = Math.Max(discount, promotion.CalculateDiscount(total));
                if (!(discountNew > discount)) continue;
                appliedPromotionId = promotion.PromotionId;
                discount = discountNew;
            }
        }

        return new CalculateResponse()
        {
            Discount = discount,
            AppliedPromotionId = appliedPromotionId
        };
    }

    private bool IsVasItemCheck(int sellerId, int catId)
    {
        // only this seller and cat id 
        if (sellerId == 5003 && catId == 3242)
        {
            return false;
        }

        return true;
    }

    private bool IsAddItemVasItemCheck(int sellerId, int catId)
    {
        // this seller and cat id is only vas item
        if (sellerId == 5003 || catId == 3242)
        {
            return true;
        }

        return false;
    }
}