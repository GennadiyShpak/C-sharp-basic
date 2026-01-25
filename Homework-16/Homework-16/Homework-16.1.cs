namespace Homework_16.Exeptions;

class Homework_16_1
{
    public static void Process()
    {
        Console.WriteLine("Please dividend number");

        var dividend = Console.ReadLine();

        try
        {
            if (!decimal.TryParse(dividend, out var convertedDividend))
            {
                throw new NaNException(dividend);
            }
        }
        catch (NaNException err)
        {
            Console.WriteLine(err.Message);
        }

        Console.WriteLine("Please divisor number");

        var divisor = Console.ReadLine();

        try
        {
            if (!decimal.TryParse(divisor, out var convertedDivisor))
            {
                throw new NaNException(divisor);
            }
        }
        catch (NaNException err)
        {
            Console.WriteLine(err.Message);
        }

        try
        {
            var result = decimal.Parse(dividend) / decimal.Parse(divisor);
            Console.WriteLine(result);
        }
        catch (DivideByZeroException err)
        {
            Console.WriteLine(err.Message);
        }
        catch (FormatException err)
        {
            Console.WriteLine(err.Message);
        }
        finally
        {
            Console.WriteLine("The programm is finished");
        }
    }

}