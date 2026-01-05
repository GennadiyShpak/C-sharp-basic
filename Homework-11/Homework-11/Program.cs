Calculator.CalculateFibonacci();

class Calculator
{


    private static int GetFibonacci(int n)
    {
        if (n <= 1)
            return n;

        return GetFibonacci(n - 1) + GetFibonacci(n - 2);
    }

    public static void CalculateFibonacci()
    {
        Console.WriteLine("Provide nubmer");
        var userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int borderNumber))
        {
            var result = GetFibonacci(borderNumber);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Your number incorrect");
        }
    }
}
