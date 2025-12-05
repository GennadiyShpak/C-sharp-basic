string[] weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

Console.WriteLine("Enter day number form 1 to 7");
var dayNumber = Console.ReadLine();
int weekDay;

if (int.TryParse(dayNumber, out int day) && day <= 8 && day >= 1)
{
    weekDay = day;
}
else
{
    Console.WriteLine("Error, next time please provide correct number");
    return;
}

//SOLUTION  1

Console.WriteLine($"You have choosen {weekDays[weekDay - 1]}");

//SOLUTION 2

void showWeekDay(string day)
{
    Console.WriteLine($"You have choosen {day}");
}
;

switch (weekDay)
{
    case 1:
        showWeekDay("Monday");
        break;
    case 2:
        showWeekDay("Tuesday");
        break;
    case 3:
        showWeekDay("Wednesday");
        break;
    case 4:
        showWeekDay("Thursday");
        break;
    case 5:
        showWeekDay("Friday");
        break;
    case 6:
        showWeekDay("Saturday");
        break;
    default:
        showWeekDay("Sunday");
        break;
}
;
