namespace Homework_14;

internal class Product
{
    protected virtual string Name { get; } = string.Empty;
    protected readonly decimal Price = 0m;

    public Product(decimal price)
    {
        Price = price;
    }

    public virtual void ShowProductInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}");
    }

    public virtual decimal GetPrice()
    {
        return Price;
    }
}
