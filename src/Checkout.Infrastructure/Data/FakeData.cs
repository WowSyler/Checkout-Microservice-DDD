namespace Checkout.Infrastructure.Data;

public static class FakeData
{
    public static void SetFakeData()
    {
        for (int i = 0; i < 5; i++)
        {
            FakeDbContext.Carts.Add("test"+i);
        }
        
    }
}