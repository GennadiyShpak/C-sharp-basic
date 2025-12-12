Console.WriteLine("Provide number");
var userInput = Console.ReadLine();


if (int.TryParse(userInput, out int number) && number > 0 && number <= 10)
{
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"{i * number}");
    }
}
else
{
    Console.WriteLine("Your input invalid");
}
