using Shared;

var days = AdventOfCodeManager.FindAllAdventOfCodeDays();

int chosenDay = 0;

do
{
    Console.Clear();
    Console.WriteLine("Welcome to Advent of Code 2024!");
    Console.WriteLine("Which day would you like to run?");
    foreach(var d in days)
    {
        Console.WriteLine($"[{d.Key,0:00}] Day {d.Key}");
    }
    Console.WriteLine();

} while (!int.TryParse(Console.ReadLine(), out chosenDay) || !days.ContainsKey(chosenDay));
Console.WriteLine();
Console.WriteLine();


var day = days[chosenDay];
var result = day.Execute();

Console.WriteLine($"Day {chosenDay} result:");
Console.WriteLine(result);