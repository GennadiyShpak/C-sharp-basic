Console.WriteLine("Provide nubmer");
var userInput = Console.ReadLine();
List<int> collection = new List<int> { 0, 1 };

int getSum(int currentNumber)
{
    return collection[currentNumber - 2] + collection[currentNumber - 1];   
}

if (int.TryParse(userInput, out int borderNumber) && borderNumber > 1)
{
    for (int i = 2; i < borderNumber; i++)
    {
        var currentResult = getSum(i);
        collection.Add(currentResult);
    }
    string result = string.Join(", ", collection.Take(borderNumber));
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Your number incorrect");
}
