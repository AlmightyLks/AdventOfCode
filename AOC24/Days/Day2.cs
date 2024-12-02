using Shared;

namespace AOC24.Days;

internal class Day2 : IDay
{
    public int Day => 2;

    public IEnumerable<object> Execute()
    {
#if DEBUG
        // Example Data for debugging
        string[] input = [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
            ];
#else
        string[] input = File.ReadAllLines(@".\Days\Day2.cs.txt");
#endif
        int result = 0;

        Parallel.ForEach(input, (line, _, i) =>
        {
            bool safe = true;
            bool? ascending = null;
            var nums = line.Split(' ').Select(int.Parse).ToList();

            for (int j = 1; j < nums.Count; j++)
            {
                var diff = nums[j - 1] - nums[j];
                var asc = diff < 0;
                if (ascending != null && ascending != asc)
                {
                    ascending = asc;
                    safe = false;
                    break;
                }
                ascending = asc;

                diff = Math.Abs(diff);

                if (diff is 0 or > 3)
                {
                    safe = false;
                    break;
                }
            }

            if (safe)
                Interlocked.Increment(ref result);
        });

        // Part 1
        yield return result;
    }
}