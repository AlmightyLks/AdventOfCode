using Shared;

var days = AdventOfCodeManager.FindAllAdventOfCodeDays();

int chosenDay = 1;

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

} while (days.Count != 1 && !int.TryParse(Console.ReadLine(), out chosenDay) || !days.ContainsKey(chosenDay));
Console.WriteLine();
Console.WriteLine();

var day = days[chosenDay];

Console.WriteLine($"Day {chosenDay} results:");
int part = 1;
foreach(var result in day.Execute())
{
    Console.WriteLine($"Part {part++}: {result}");
}