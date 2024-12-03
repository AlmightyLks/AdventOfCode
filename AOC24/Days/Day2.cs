using Shared;

namespace AOC24.Days;

public class Day2 : IDay
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

        // Part 1
        yield return CalculateResult(input, false);
        // Part 2
        yield return CalculateResult(input, true);
    }
    private static int CalculateResult(string[] input, bool skipLevels)
    {
        int result = 0;

        Parallel.ForEach(input, (line, _, i) =>
        {
            var nums = line.Split(' ').Select(int.Parse).ToList();
            var combs = GetCombinations(nums);

            if (combs.Select(GetErrors).Any(x => x <= 0))
                Interlocked.Increment(ref result);
        });

        return result;

        int GetErrors(List<int> nums)
        {
            int errors = 0;
            bool? previouslyAscending = null;

            for (int j = 1; j < nums.Count; j++)
            {
                var diff = nums[j - 1] - nums[j];
                var nowAscending = diff < 0;

                if (previouslyAscending != null && previouslyAscending != nowAscending)
                {
                    errors++;
                }

                previouslyAscending = nowAscending;

                diff = Math.Abs(diff);

                if (diff is 0 or > 3)
                {
                    errors++;
                }
            }

            return errors;
        }

        List<List<int>> GetCombinations(List<int> input)
        {
            if (skipLevels)
            {
                var combinations = new List<List<int>>();

                for (int i = 0; i < input.Count; i++)
                {
                    combinations.Add([.. input[..i], .. input[(i + 1)..]]);
                }

                return combinations;
            }
            else
            {
                return [input];
            }
        }
    }
}