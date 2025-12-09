string asterisk = "*";
int level = int.Parse(Console.ReadLine());
Console.WriteLine("Result:");

for (int i = 1; i <= level; i++)
{
    Console.WriteLine(asterisk);
    asterisk += "*";
}