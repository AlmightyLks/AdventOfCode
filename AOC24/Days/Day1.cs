using Shared;

namespace AOC24.Days;

internal class Day1 : IDay
{
    public int Day => 1;

    public IEnumerable<object> Execute()
    {
        List<int> inputLeft = [];
        List<int> inputRight = [];

#if DEBUG
        // Example Data for debugging
        inputLeft = [3, 4, 2, 1, 3, 3];
        inputRight = [4, 3, 5, 3, 9, 3];
#else
        foreach (var line in File.ReadAllLines(@".\Days\Day1.cs.txt"))
        {
            var split = line.Split("   ");
            inputLeft.Add(int.Parse(split[0]));
            inputRight.Add(int.Parse(split[1]));
        }
#endif

        inputLeft.Sort();
        inputRight.Sort();

        // Part 1
        yield return inputLeft.Select((x, i) => Math.Abs(x - inputRight[i])).Sum();

        // Part 2
        yield return inputLeft.Select(x => x * inputRight.Count(y => y == x)).Sum();
    }
}
