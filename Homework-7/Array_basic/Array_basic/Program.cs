using Enums;

Random random = new Random();

var TEN = (int)Numbers.Ten;
var NINE = (int)Numbers.Nine;
var FIVE = (int)Numbers.Five;


//Task 7.1.1 Array creation
int[] randomNumbers = new int[TEN];

int GenerateRandomInt(int minValue, int maxValue)
{
    return random.Next(minValue, maxValue);
}

void ShowEvenIndex(int index, int value)
{
    if (index % 2 ==0)
    {
        Console.WriteLine($"Even value {value}");
    }
}

int GetSum(int[] array) => array.Sum();

for (int i = 0; i < TEN; i++)
{
    randomNumbers[i] = GenerateRandomInt(TEN * -1, TEN);

    ShowEvenIndex(i, randomNumbers[i]);
}

// Task 7.1.2 Sum of elements comparison

var sumOfElements = GetSum(randomNumbers);

var sumStatus = sumOfElements > 0 ? "bigger" : "smaller";

Console.WriteLine($"Sum of element is {sumOfElements}, and it {sumStatus} than 0");

// Task 7.1.3 Multiplication table

int[,] GenerateTwoLevelObject(int topLevelSize, int nestedArraySize, Func<int, int, int> callback)
{
    int[,] array = new int[topLevelSize, nestedArraySize];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = callback(i, j);
        }
    }

    return array;
}

int MultiplyCallback(int i, int j)
{
    return (i + 1) * (j + 1);
}

int[,] multiplicationTable = GenerateTwoLevelObject(NINE, NINE, MultiplyCallback);

// Task 7.1.4 Find max element in array

int[,] twoLevelArray = GenerateTwoLevelObject(FIVE, FIVE, (_i, _j) => GenerateRandomInt(-1000, 1000));
int maxElement = 0;
int[] maxElementCoordinates = new int[2];
int minElement = 0;
int[] minElementCoordinates = new int[2];

for (int i = 0; i < twoLevelArray.GetLength(0); i++)
{
    for (int j = 0; j < twoLevelArray.GetLength(1); j++)
    {
        if (twoLevelArray[i,j] > maxElement)
        {   maxElement = twoLevelArray[i, j];
            maxElementCoordinates = [i, j];
        }
        if (twoLevelArray[i,j] < minElement)
        {   minElement = twoLevelArray[i, j];
            minElementCoordinates = [i, j];
        }
    }
}

Console.WriteLine($"Max element is {maxElement} at coordinates [{maxElementCoordinates[0]}, {maxElementCoordinates[1]}]");
Console.WriteLine($"Min element is {minElement} at coordinates [{minElementCoordinates[0]}, {minElementCoordinates[1]}]");

// Task 7.1.5 Days of the week
Console.Write("Please provide day number: ");
string userInut = Console.ReadLine();
uint handleUserInput(string input)
{
    bool isParsed = uint.TryParse(input, out uint dayNumber);
    if (!isParsed || dayNumber == 0)
    {
        Console.WriteLine("Invalid input, please provide a number between 1 and 65535");
        userInut = Console.ReadLine();
        return handleUserInput(userInut);
    }

    return dayNumber;
}
uint dayNumber = (handleUserInput(userInut!) % 7) + 1;

dayNumber = dayNumber > 7 ? dayNumber - 7 : dayNumber;
string dayName = ((DaysOfWeek)dayNumber).ToString();
Console.WriteLine($"Entry number - {userInut}, day - {dayName}");
