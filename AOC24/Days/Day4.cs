using Shared;
using System.Data.Common;
using System.Text;

namespace AOC24.Days;

public partial class Day4 : IDay
{
    public int Day => 4;

    public IEnumerable<object> Execute()
    {
#if DEBUG
        string[] input = [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
            ];
#else
        string[] input = File.ReadAllLines(@".\Days\Day4.cs.txt");
#endif

        yield return CountAll(input);

        // Dont wanna do Part 2. The task sucks
    }

    private static int CountAll(string[] input)
    {
        var horizontal = CountXmasHorizontally(input);
        var vertical = CountXmasVertically(input);
        var diagonal = CountXmasDiagonally(input);
        return horizontal + vertical + diagonal;
    }

    private static int CountXmasHorizontally(string[] input)
    {
        int result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            Count(input[i], "XMAS", ref result);
            Count(new string(input[i].Reverse().ToArray()), "XMAS", ref result);
        }

        return result;
    }

    private static int CountXmasVertically(string[] input)
    {
        int result = 0;

        for (int i = 0; i < input[0].Length; i++)
        {
            var str = new string(input.Select(x => x[i]).ToArray());
            Count(str, "XMAS", ref result);
            Count(new string(str.Reverse().ToArray()), "XMAS", ref result);
        }

        return result;

    }

    private static int CountXmasDiagonally(string[] input)
    {
        int result = 0;

        var diagonalStrings = GetDiagonalStrings(input);

        for (int i = 0; i < diagonalStrings.Count; i++)
        {
            Count(diagonalStrings[i], "XMAS", ref result);
            Count(new string(diagonalStrings[i].Reverse().ToArray()), "XMAS", ref result);
        }

        return result;

    }

    private static List<string> GetDiagonalStrings(string[] input)
    {
        List<string> diagonals = new List<string>();

        int rows = input.Length;
        if (rows == 0) return diagonals;

        int cols = input[0].Length;

        // Right-to-Left diagonals
        for (int d = 0; d < rows + cols - 1; d++)
        {
            string diagonal = "";
            for (int row = 0; row < rows; row++)
            {
                int col = d - row;
                if (col >= 0 && col < cols)
                {
                    diagonal += input[row][col];
                }
            }
            if (diagonal.Length > 0)
                diagonals.Add(diagonal);
        }

        // Left-to-Right diagonals
        for (int d = 0; d < rows + cols - 1; d++)
        {
            string diagonal = "";
            for (int row = 0; row < rows; row++)
            {
                int col = (cols - 1) - (d - row);
                if (col >= 0 && col < cols)
                {
                    diagonal += input[row][col];
                }
            }
            if (diagonal.Length > 0)
                diagonals.Add(diagonal);
        }

        return diagonals;
    }

    private static void Count(string input, string searchString, ref int result)
    {
        int resultBefore = result;

        int lastFoundIndex = -1;
        do
        {
            lastFoundIndex = input.IndexOf(searchString, lastFoundIndex + 1);
            if (lastFoundIndex != -1)
                result++;
        } while (lastFoundIndex != -1);
    }
}
