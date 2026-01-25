namespace Homework_14;

internal class Potato : ProductWithWeight
{
    protected override string Name => "Potato";

    public Potato(decimal price, double weight) : base(price, weight)
    {
    }
}
