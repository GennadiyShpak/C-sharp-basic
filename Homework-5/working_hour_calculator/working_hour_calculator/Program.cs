Console.WriteLine("Provide number from 1 to 24");
var userInput = Console.ReadLine();
const double COEF = 1.25;
const int PRICE = 10;

double calculateHourPrice(double rateMultiplier)
{
    double multiplier = rateMultiplier > 0 ? COEF * rateMultiplier : 1;

    return PRICE * multiplier;

}

double getHourPrice(int hour) => hour switch
{
    > 4 and <= 8 => calculateHourPrice(1.5),
    >= 9 and <= 12 => calculateHourPrice(1.6),
    >= 13 and <= 16 => calculateHourPrice(1.7),
    >= 17 and <= 20 => calculateHourPrice(1.8),
    >= 21 and <= 24 => calculateHourPrice(2),
    _ => calculateHourPrice(0)
};

if (int.TryParse(userInput, out int workingHours) && workingHours <= 24 && workingHours >= 1)
{
    double result = 0;

    for (int i = 1; i <= workingHours; i++)
    {
        result += getHourPrice(i);
    }
    Console.WriteLine($"Total pay for {workingHours} hour(s): {result}");
}
else
{
    Console.WriteLine("You are provided incorrect data");
}
