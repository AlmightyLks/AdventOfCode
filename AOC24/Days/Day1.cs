using Shared;

namespace AOC24.Days;

internal class Day1 : IDay
{
    public int Day => 1;

    public IEnumerable<object> Execute()
    {
        List<int> inputLeft = [];
        List<int> inputRight = [];

        foreach (var line in File.ReadAllLines(@".\Days\Day1.cs.txt"))
        {
            var split = line.Split("   ");
            inputLeft.Add(int.Parse(split[0]));
            inputRight.Add(int.Parse(split[1]));
        }

        inputLeft.Sort();
        inputRight.Sort();

        yield return inputLeft.Select((x, i) => Math.Abs(x - inputRight[i])).Sum();
    }
}
