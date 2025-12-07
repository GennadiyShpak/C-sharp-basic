string[] operators = ["+", "-", "/", "*"];
decimal firstOperand;
decimal secondOperand;
string action;

bool isUserInputValid(string input)
{
    return decimal.TryParse(input, out _);
}

decimal getUserInput()
{
    Console.WriteLine("Enter number");
    var userInput = Console.ReadLine();

    if (!isUserInputValid(userInput))
    {
        Console.WriteLine("Dude you have made huge error");
        return getUserInput();
    }
    else
    {
        return Convert.ToDecimal(userInput);
    }
}

string getOperator()
{
    Console.WriteLine("Provide operation type");
    string operation = Console.ReadLine().Trim();

    if (!validateOperator(operation))
    {
        Console.WriteLine("Dude you have provided wrong operation");
        return getOperator();
    }

    return operation;
}

bool validateOperator(string operation)
{
    return operators.Contains(operation);
}

firstOperand = getUserInput();
action = getOperator();
secondOperand = getUserInput();

switch(action)
{
    case "+":
        Console.WriteLine($"{firstOperand + secondOperand}");
        break;
    case "-":
        Console.WriteLine($"{firstOperand - secondOperand}");
        break;
    case "/":
        Console.WriteLine($"{firstOperand / secondOperand}");
        break;
    case "*":
        Console.WriteLine($"{firstOperand * secondOperand}");
        break;
}