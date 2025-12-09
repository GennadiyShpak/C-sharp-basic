const string STOP_WORD = "stop";
decimal averageSalary = 0;
var shouldAskSalary = true;
var counter = 0;

do
{
    Console.WriteLine("Provide salary of employee");
    var userInput = Console.ReadLine();
    shouldAskSalary = userInput != STOP_WORD;
    if (int.TryParse(userInput, out int salary))
    {
        averageSalary += salary;
        counter++;
    }
    else if (!shouldAskSalary)
    {
        Console.WriteLine($"The average salary is: {averageSalary / counter}");
    }
    else
    {
        Console.WriteLine("You provided wrong value. Please try again");
    }
} while (shouldAskSalary);
