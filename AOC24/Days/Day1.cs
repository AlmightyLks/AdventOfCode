using Shared;

namespace AOC24.Days;

internal class Day1 : IDay
{
    public int Day => 1;

    public object Execute()
    {
        List<int> inputLeft = [];
        List<int> inputRight = [];
        List<int> distances = [];

        var day1Lines = File.ReadAllLines(@".\Days\Day1.cs.txt");

        foreach (var line in day1Lines)
        {
            var split = line.Split("   ");
            inputLeft.Add(int.Parse(split[0]));
            inputRight.Add(int.Parse(split[1]));
        }

        inputLeft.Sort();
        inputRight.Sort();

        for (int i = 0; i < inputLeft.Count; i++)
        {
            distances.Add(Math.Abs(inputLeft[i] - inputRight[i]));
        }

        return distances.Sum();
    }
}
