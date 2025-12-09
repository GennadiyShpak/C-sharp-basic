Console.WriteLine("Enter number");
string userInput = Console.ReadLine();
var result = "";

bool checkIsPrime(int number, int borderNumber)
{
    for (int i = 2; i < borderNumber; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }

    return true;
}

if (int.TryParse(userInput, out int borderNumber))
{
    int square = (int)Math.Sqrt(borderNumber);

    for (int i = 2; i <= borderNumber; i++)
    {
        if (checkIsPrime(i, square))
        {
            result += $"{i} ";
        }
    }
}
else
{
    Console.WriteLine("You provided invalid number");
}

Console.WriteLine($"The result is {result.TrimEnd()}");
