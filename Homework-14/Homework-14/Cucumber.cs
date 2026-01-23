namespace Homework_14;

internal class Cucumber : ProductWithWeight
{
    protected override string Name => "Cucumber";

    public Cucumber(decimal price, double weight) : base(price, weight)
    {
    }
}
