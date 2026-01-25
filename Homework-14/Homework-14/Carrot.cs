namespace Homework_14;

internal class Carrot : Product
{
    protected override string Name => "Carrot";

    public Carrot(decimal price) : base(price)
    {
    }
}
