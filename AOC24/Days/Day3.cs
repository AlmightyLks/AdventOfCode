using Shared;
using System.Text.RegularExpressions;

namespace AOC24.Days;

public partial class Day3 : IDay
{
    public int Day => 3;

    [GeneratedRegex("mul\\(([0-9]+)\\,([0-9]+)\\)", RegexOptions.Compiled)]
    private static partial Regex MultiplyRegex();

    public IEnumerable<object> Execute()
    {
#if DEBUG
        // Example Data for debugging
        string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
#else
        string input = File.ReadAllText(@".\Days\Day3.cs.txt");
#endif

        yield return CalculateResult(input, false);

#if DEBUG
        // Example Data for debugging
        input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
#endif

        yield return CalculateResult(input, true);
    }

    private static int CalculateResult(string input, bool respectDonts)
    {
        var inputSpan = input.AsSpan();
        int result = 0;

        var matches = MultiplyRegex().Matches(input);

        foreach (Match match in matches)
        {
            if (respectDonts)
            {
                var slice = inputSpan[..match.Index];
                int dontIndex = slice.LastIndexOf("don't()");
                int doIndex = slice.LastIndexOf("do()");

                if (dontIndex > doIndex)
                    continue;
            }

            var num1 = match.Groups[1].Value;
            var num2 = match.Groups[2].Value;
            result += int.Parse(num1) * int.Parse(num2);
        }

        return result;
    }
}
