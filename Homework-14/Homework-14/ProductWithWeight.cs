namespace Homework_14;

internal class ProductWithWeight : Product
{
    private readonly double Weight = 0;
    private decimal TotalPrice = 0;

    public ProductWithWeight(decimal price, double weight) : base(price)
    {
        Weight = weight;
        TotalPrice = Price * (decimal)Weight;
    }

    public override void ShowProductInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}, Count: {Weight}, Total price: {TotalPrice}");
    }

    public override decimal GetPrice()
    {
        return TotalPrice;
    }
}
